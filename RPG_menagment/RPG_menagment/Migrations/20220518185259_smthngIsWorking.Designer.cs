// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPG_menagment.Data;

namespace RPG_menagment.Migrations
{
    [DbContext(typeof(RPGcontext))]
    [Migration("20220518185259_smthngIsWorking")]
    partial class smthngIsWorking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+Cave", b =>
                {
                    b.Property<int>("CaveID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CaveID");

                    b.ToTable("Caves");
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+Dragon", b =>
                {
                    b.Property<int>("DragonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FightingCharacterID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<float>("Wingspan")
                        .HasColumnType("real");

                    b.Property<int>("dragonSpicies")
                        .HasColumnType("int");

                    b.HasKey("DragonID");

                    b.HasIndex("FightingCharacterID");

                    b.HasIndex("UserID");

                    b.ToTable("Dragons");
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+FightingCharacter", b =>
                {
                    b.Property<int>("FightingCharacterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FightingCharacterID");

                    b.ToTable("FightingCharacters");
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+Forest", b =>
                {
                    b.Property<int>("ForestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ForestID");

                    b.ToTable("Forests");
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+Magician", b =>
                {
                    b.Property<int>("MagicianID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FightingCharacterID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("MagicianID");

                    b.HasIndex("FightingCharacterID");

                    b.HasIndex("UserID");

                    b.ToTable("Magicians");
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+Orc", b =>
                {
                    b.Property<int>("OrcID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FightingCharacterID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrcID");

                    b.HasIndex("FightingCharacterID");

                    b.HasIndex("UserID");

                    b.ToTable("Orcs");
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+River", b =>
                {
                    b.Property<int>("RiverID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RiverID");

                    b.ToTable("Rivers");
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+Soldier", b =>
                {
                    b.Property<int>("SoldierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FightingCharacterID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<string>("Swordname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("SoldierID");

                    b.HasIndex("FightingCharacterID");

                    b.HasIndex("UserID");

                    b.ToTable("Soldiers");
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+Tower", b =>
                {
                    b.Property<int>("TowerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TowerID");

                    b.ToTable("Towers");
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+Dragon", b =>
                {
                    b.HasOne("RPG_menagment.Data.Model.RPGmodel+FightingCharacter", "fightingCharacter")
                        .WithMany()
                        .HasForeignKey("FightingCharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPG_menagment.Data.Model.RPGmodel+User", "user")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+Magician", b =>
                {
                    b.HasOne("RPG_menagment.Data.Model.RPGmodel+FightingCharacter", "fightingCharacter")
                        .WithMany()
                        .HasForeignKey("FightingCharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPG_menagment.Data.Model.RPGmodel+User", "user")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+Orc", b =>
                {
                    b.HasOne("RPG_menagment.Data.Model.RPGmodel+FightingCharacter", "fightingCharacter")
                        .WithMany()
                        .HasForeignKey("FightingCharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPG_menagment.Data.Model.RPGmodel+User", "user")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RPG_menagment.Data.Model.RPGmodel+Soldier", b =>
                {
                    b.HasOne("RPG_menagment.Data.Model.RPGmodel+FightingCharacter", "fightingCharacter")
                        .WithMany()
                        .HasForeignKey("FightingCharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPG_menagment.Data.Model.RPGmodel+User", "user")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
