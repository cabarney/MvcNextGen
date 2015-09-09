using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using EmptyWeb;

namespace EmptyWebMigrations
{
    [ContextType(typeof(TestContext))]
    partial class initial
    {
        public override string Id
        {
            get { return "20150909182859_initial"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815")
                .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn");

            builder.Entity("EmptyWeb.Thing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Key("Id");
                });
        }
    }
}
