﻿// <auto-generated />
using System;
using Janus.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Janus.Persistence.Migrations
{
    [DbContext(typeof(JanusDbContext))]
    partial class JanusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Janus.Domain.Entities.Categories", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime?>("DateAdded");

                    b.Property<Guid>("TenantID");

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Janus.Domain.Entities.Clients", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("DateTimeLogged");

                    b.Property<string>("MainContact");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("State");

                    b.Property<Guid>("TenantID");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Janus.Domain.Entities.ComputerID", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BiosManufacturer");

                    b.Property<string>("BiosName");

                    b.Property<string>("BiosSerialNumber");

                    b.Property<string>("BiosStatus");

                    b.Property<string>("BiosVersion");

                    b.Property<string>("ComputerName");

                    b.Property<DateTime>("DateTimeUpdated");

                    b.Property<string>("Domain");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Model");

                    b.Property<string>("RAM");

                    b.Property<string>("SkuNumber");

                    b.Property<Guid>("TenantID");

                    b.HasKey("ID");

                    b.ToTable("ComputerIDs");
                });

            modelBuilder.Entity("Janus.Domain.Entities.HardDrives", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ComputerID");

                    b.Property<Guid?>("ComputerIDID");

                    b.Property<string>("DateTimeAdded");

                    b.Property<string>("DateTimeEdited");

                    b.Property<string>("Description");

                    b.Property<string>("FileSystem");

                    b.Property<string>("FreeSpace");

                    b.Property<string>("Name");

                    b.Property<string>("SerialNumber");

                    b.Property<Guid>("TenantID");

                    b.Property<string>("TotalSpace");

                    b.HasKey("ID");

                    b.HasIndex("ComputerIDID");

                    b.ToTable("HardDrives");
                });

            modelBuilder.Entity("Janus.Domain.Entities.Network", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComputerID");

                    b.Property<string>("DNS01");

                    b.Property<string>("DNS02");

                    b.Property<DateTime?>("DateTimeAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("DhcpEnabled");

                    b.Property<string>("DhcpServer");

                    b.Property<string>("DnsDomain");

                    b.Property<string>("Gateway");

                    b.Property<string>("IpAddressV4");

                    b.Property<string>("IpAddressV6");

                    b.Property<string>("MacAddress");

                    b.Property<string>("SubNet");

                    b.Property<Guid>("TenantID");

                    b.HasKey("ID");

                    b.ToTable("Network");
                });

            modelBuilder.Entity("Janus.Domain.Entities.Status", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("Order");

                    b.Property<string>("TenantID");

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Janus.Domain.Entities.Techs", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateLogged");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<Guid>("TenantID");

                    b.HasKey("ID");

                    b.ToTable("Techs");
                });

            modelBuilder.Entity("Janus.Domain.Entities.TenantID", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("DateLogged");

                    b.HasKey("ID");

                    b.ToTable("TenantIDs");
                });

            modelBuilder.Entity("Janus.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryID");

                    b.Property<Guid?>("ComputerID");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateTimeCreated");

                    b.Property<DateTime>("DateTimeEdited");

                    b.Property<DateTime>("DateTimeFinished");

                    b.Property<DateTime>("DateTimeStarted");

                    b.Property<string>("Message");

                    b.Property<Guid?>("StatusID");

                    b.Property<Guid?>("SubCategoryID");

                    b.Property<string>("SubmittedBy");

                    b.Property<Guid>("TenantID");

                    b.Property<int>("TicketNumber");

                    b.Property<string>("TicketOwner");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ComputerID");

                    b.HasIndex("StatusID");

                    b.HasIndex("SubCategoryID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Janus.Domain.Entities.TicketComments", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DateTimeCreated");

                    b.Property<string>("Message");

                    b.Property<string>("PostedBy");

                    b.Property<Guid>("TenantID");

                    b.Property<Guid>("TicketID");

                    b.HasKey("ID");

                    b.ToTable("TicketComments");
                });

            modelBuilder.Entity("Janus.Domain.Entities.WindowsUpdates", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption");

                    b.Property<Guid?>("ComputerIDID");

                    b.Property<DateTime>("DateTimeAdded");

                    b.Property<string>("Description");

                    b.Property<string>("HostName");

                    b.Property<string>("HotFixID");

                    b.Property<string>("InstalledOn");

                    b.Property<Guid>("TenantID");

                    b.HasKey("ID");

                    b.HasIndex("ComputerIDID");

                    b.ToTable("WindowsUpdates");
                });

            modelBuilder.Entity("Janus.Domain.Entities.HardDrives", b =>
                {
                    b.HasOne("Janus.Domain.Entities.ComputerID")
                        .WithMany("HardDrives")
                        .HasForeignKey("ComputerIDID");
                });

            modelBuilder.Entity("Janus.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Janus.Domain.Entities.Categories", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("Janus.Domain.Entities.ComputerID", "Computer")
                        .WithMany("Tickets")
                        .HasForeignKey("ComputerID");

                    b.HasOne("Janus.Domain.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID");

                    b.HasOne("Janus.Domain.Entities.Categories", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryID");
                });

            modelBuilder.Entity("Janus.Domain.Entities.WindowsUpdates", b =>
                {
                    b.HasOne("Janus.Domain.Entities.ComputerID", "ComputerID")
                        .WithMany()
                        .HasForeignKey("ComputerIDID");
                });
#pragma warning restore 612, 618
        }
    }
}
