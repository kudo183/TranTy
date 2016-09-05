using System.Data.Entity;

namespace TranTy.Entity
{
    public class TranTyContext : DbContext 
    {
        //level 0
        public DbSet<Bep> Beps { get; set; }
        public DbSet<LoaiChiPhi> LoaChiPhis { get; set; }
        public DbSet<Version> Versions { get; set; }

        //level 1
        public DbSet<ChiPhiBep> ChiPhiBeps { get; set; }
    }
}
