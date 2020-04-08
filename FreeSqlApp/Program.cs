using FindToilet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeSqlApp
{
    class Program
    {
        static readonly string connstr = "Data Source=.;Integrated Security=True;Initial Catalog=FindToilet;Pooling=true;Min Pool Size=1";

        static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, connstr)
            .UseAutoSyncStructure(true) //自动同步实体结构到数据库
            .Build(); //请务必定义成 Singleton 单例模式

        static void Main(string[] args)
        {
            //Select();
            //Insert();
            //Update();
            //Update1();
            Delete();
        }

        #region 查询
        private static void Select()
        {
            List<T_City> list =  fsql.Queryable<T_City>().Where(x=>x.name.Contains("省")).ToList();
            foreach (var item in list)
            {
                Console.WriteLine("所属省份：" + item.name);
            }
            Console.ReadKey();
        }
        #endregion

        #region 插入
        private static void Insert()
        {
            T_User model = new T_User();
            model.create_date = DateTime.Now;
            model.create_id = 1;
            model.delete_flag = 0;
            model.modify_date = DateTime.Now;
            model.modify_id = 1;
            model.name = "刘德华";
            long result = fsql.Insert(model).ExecuteIdentity();
            if(result >0)
                Console.WriteLine("插入成功，ID值为：" + result.ToString());
            else
                Console.WriteLine("插入失败");
            Console.ReadKey();
        }
        #endregion

        #region 按实体更新
        private static void Update()
        {
            #region  整个实体更新
            var item = new T_User { user_id = 1, name = "郭富城" };
            int result = fsql.Update<T_User>()
              .SetSource(item)
              .ExecuteAffrows();
            #endregion

            if (result > 0)
                Console.WriteLine("更新成功，影响的行数为：" + result.ToString());
            else
                Console.WriteLine("更新失败");
            Console.ReadKey();
        }
        #endregion

        #region 按照列更新
        private static void Update1()
        {
            #region  按照列更新
            int result = fsql.Update<T_User>()
                .SetRaw("name = @name", new { name = "刘德华" })
                .Where("user_id = @user_id", new { user_id = 1})
                .ExecuteAffrows();
            #endregion

            if (result > 0)
                Console.WriteLine("更新成功，影响的行数为：" + result.ToString());
            else
                Console.WriteLine("更新失败");
            Console.ReadKey();
        }
        #endregion

        #region 删除
        private static void Delete()
        {
            long result = fsql.Delete<T_User>().Where(a => a.user_id == 1).ExecuteAffrows();
            if (result > 0)
                Console.WriteLine("删除成功，影响行数为：" + result.ToString());
            else
                Console.WriteLine("删除失败");
        }
        #endregion
    }
}
