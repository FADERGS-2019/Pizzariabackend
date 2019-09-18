namespace PizzariaDosGuri.DAL.Migrations.DataInitializer.Contract
{
    public interface IDataInitializer
    {
        void Initialize(PizzariaDataContext context);
    }
}
