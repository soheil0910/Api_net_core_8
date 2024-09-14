using Api_net_core_8.Models;
using Api_net_core_8.Models.Pc;
using Microsoft.EntityFrameworkCore;

namespace Api_net_core_8.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<PC> Pc { get; set; }
        public DbSet<PcDetails> PcDetails { get; set; }
        public DbSet<PcCpu> PcCpu { get; set; }
        public DbSet<PcFan> PcFan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            #region Seed Data

            modelBuilder.Entity<PC>().HasData(new PC()
            {
                Id = 1,
                Name = "G1",
                DescriptionId = 1,

            },new PC()
            {
                Id = 2,
                Name = "G2",
                DescriptionId = 2,

            }

                 );
            //---------------------------------------------------------

            modelBuilder.Entity<PcDetails>().HasData(new PcDetails()
            {
                Id = 1,
                Description="سه تا صد گونی هزار",
                Ram="1GB",
                MotherBord="sd10",
                Power="120W",
                PcCpuId=1,

            },new PcDetails()
            {
                Id = 2,
                Description="قول مرحله اخر",
                Ram="200GB",
                MotherBord="zf10",
                Power="2300W",
                PcCpuId=2,

            }

                 );
            //---------------------------------------------------------

            modelBuilder.Entity<PcCpu>().HasData(new PcCpu()
            {
                Id = 1,
                Name="I9 13900K",
                Model="2023",
                PcFanId=1,

            },new PcCpu()
            {
                Id = 2,
                Name="I9 14900K",
                Model="2024",
                PcFanId=1,

            }

                 );
            
            //---------------------------------------------------------

            modelBuilder.Entity<PcFan>().HasData(new PcFan()
            {
                Id = 1,
                Name= "MASTERLIQUID",
                Model= "MASTERLIQUID ML360L V2 ARGB"
            }


                 );
            //---------------------------------------------------------



            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Name = "soheil",
                Family = "Robaty",
                Email = "soheil0910line@gmail.com",
                Password = "1234",
                UserName = "soheil0910",

            }, new User()
            {
                Id = 2,
                Name = "ali",
                Family = "Robaty",

                Password = "1234",
                UserName = "ali001",

            }

                 );
            //---------------------------------------------------------

            modelBuilder.Entity<Car>().HasData(new Car()
            {
                Id = 1,
                Name = "پراید",
                Description = "قوطی روغن نباطی",
                MaxSpeed = 120
            }, new Car()
            {
                Id = 2,
                Name = "پیکان",
                Description = "دیوار دفاعی",
                MaxSpeed = 110
            }, new Car()
            {
                Id = 3,
                Name = "پرشیا",
                Description = "",
                MaxSpeed = 220
            }


                );





            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
