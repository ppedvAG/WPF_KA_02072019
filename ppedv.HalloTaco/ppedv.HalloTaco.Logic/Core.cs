using ppedv.HalloTaco.Model.Contracts;

namespace ppedv.HalloTaco.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repo)
        {
            this.Repository = repo;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }

    }
}
