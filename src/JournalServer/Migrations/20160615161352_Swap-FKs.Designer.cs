using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JournalServer.Models;

namespace JournalServer.Migrations
{
    [DbContext(typeof(JournalContext))]
    [Migration("20160615161352_Swap-FKs")]
    partial class SwapFKs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JournalServer.Models.Entry", b =>
                {
                    b.Property<int>("EntryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Text");

                    b.Property<int>("UserId");

                    b.Property<int>("WordCount");

                    b.HasKey("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("JournalEntry");
                });

            modelBuilder.Entity("JournalServer.Models.EntryAnalysis", b =>
                {
                    b.Property<int>("EntryAnalysisId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Anger");

                    b.Property<int>("EntryId");

                    b.Property<decimal>("Fear");

                    b.Property<decimal>("Joy");

                    b.Property<decimal>("Sadness");

                    b.Property<decimal>("Sentiment");

                    b.Property<decimal>("Surprise");

                    b.Property<int>("UserId");

                    b.HasKey("EntryAnalysisId");

                    b.HasIndex("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("EntryAnalysis");
                });

            modelBuilder.Entity("JournalServer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateRegistered");

                    b.Property<string>("Entries");

                    b.Property<string>("EntryAnalyses");

                    b.Property<string>("Location");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("JournalServer.Models.Entry", b =>
                {
                    b.HasOne("JournalServer.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JournalServer.Models.EntryAnalysis", b =>
                {
                    b.HasOne("JournalServer.Models.Entry")
                        .WithMany()
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JournalServer.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
