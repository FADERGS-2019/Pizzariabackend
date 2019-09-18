using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaDosGuri.DAL.Migrations
{
    class Configuration : DbMigrationsConfiguration<PizzariaDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(PizzariaDataContext context)
        //{
            //new PlayerDataInitializer().Initialize(context);
        //}
    }
}