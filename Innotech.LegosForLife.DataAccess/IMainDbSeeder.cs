namespace Innotech.LegosForLife.DataAccess
{
    public interface IMainDbSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}