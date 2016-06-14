using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JournalServer.Models;

namespace JournalServer.Migrations
{
    [DbContext(typeof(JournalContext))]
    partial class JournalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JournalServer.Models.Entry", b =>
                {
                    b.Property<int>("EntryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("EntryAnalysisId");

                    b.Property<string>("Text");

                    b.Property<int>("UserId");

                    b.Property<int>("WordCount");

                    b.HasKey("EntryId");

                    b.ToTable("JournalEntry");
                });

            modelBuilder.Entity("JournalServer.Models.EntryAnalysis", b =>
                {
                    b.Property<int>("EntryAnalysisId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Anger");

                    b.Property<decimal>("Fear");

                    b.Property<decimal>("Joy");

                    b.Property<decimal>("Sadness");

                    b.Property<decimal>("Sentiment");

                    b.Property<decimal>("Surprise");

                    b.Property<int>("UserId");

                    b.HasKey("EntryAnalysisId");

                    b.ToTable("EntryAnalysis");
                });

            modelBuilder.Entity("JournalServer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateRegistered");

                    b.Property<string>("Location");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });
        }
    }
}
