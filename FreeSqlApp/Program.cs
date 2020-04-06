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
            Select();
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
    }
}
