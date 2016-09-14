using System.Data.Entity;

namespace TranTy.Entity
{
    public class TranTyContext : DbContext
    {
        public TranTyContext() : base("name=DBConnectionString")
        {

        }

        //level 0
        public DbSet<Bep> Beps { get; set; }
        public DbSet<LoaiChiPhi> LoaiChiPhis { get; set; }
        public DbSet<Version> Versions { get; set; }

        //level 1
        public DbSet<ChiPhiBep> ChiPhiBeps { get; set; }
    }
}
