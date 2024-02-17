﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WorkflowLib.Examples.ServiceInteraction.Core.Contexts;

#nullable disable

namespace WorkflowLib.Examples.ServiceInteraction.Core.Migrations
{
    [DbContext(typeof(ServiceInteractionContext))]
    partial class ServiceInteractionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcess", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("BusinessEntityStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.Property<string>("VersionNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("BusinessProcesses");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcessState", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("BusinessEntityStatus")
                        .HasColumnType("integer");

                    b.Property<long?>("BusinessProcessId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BusinessProcessId");

                    b.ToTable("BusinessProcessStates");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcessStateTransition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("BusinessEntityStatus")
                        .HasColumnType("integer");

                    b.Property<long?>("BusinessProcessId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<long?>("FromStateId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long?>("ToStateId")
                        .HasColumnType("bigint");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BusinessProcessId");

                    b.HasIndex("FromStateId");

                    b.HasIndex("ToStateId");

                    b.ToTable("BusinessProcessStateTransitions");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.DbgLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("ChangeDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SourceDetails")
                        .HasColumnType("text");

                    b.Property<string>("SourceName")
                        .HasColumnType("text");

                    b.Property<string>("SourceStatus")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DbgLogs");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.Endpoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ClassName")
                        .HasColumnType("text");

                    b.Property<int?>("EndpointDeploymentType")
                        .HasColumnType("integer");

                    b.Property<long?>("EndpointTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("IpAddress")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NetworkAddress")
                        .HasColumnType("text");

                    b.Property<int?>("Port")
                        .HasColumnType("integer");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EndpointTypeId");

                    b.ToTable("Endpoints");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.EndpointCall", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ApiMethodName")
                        .HasColumnType("text");

                    b.Property<int?>("AttemptsLimit")
                        .HasColumnType("integer");

                    b.Property<long?>("BusinessProcessStateId")
                        .HasColumnType("bigint");

                    b.Property<long?>("BusinessProcessStateTransitionId")
                        .HasColumnType("bigint");

                    b.Property<int?>("EndpointCallType")
                        .HasColumnType("integer");

                    b.Property<long?>("EndpointFromId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EndpointToId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EndpointTypeFromId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EndpointTypeToId")
                        .HasColumnType("bigint");

                    b.Property<int?>("MessageBrokerType")
                        .HasColumnType("integer");

                    b.Property<string>("QueueName")
                        .HasColumnType("text");

                    b.Property<int?>("TimeoutLimit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BusinessProcessStateId");

                    b.HasIndex("BusinessProcessStateTransitionId");

                    b.HasIndex("EndpointFromId");

                    b.HasIndex("EndpointToId");

                    b.HasIndex("EndpointTypeFromId");

                    b.HasIndex("EndpointTypeToId");

                    b.ToTable("EndpointCalls");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.EndpointType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EndpointTypes");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcess", b =>
                {
                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcess", "Parent")
                        .WithMany("SubProcesses")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcessState", b =>
                {
                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcess", "BusinessProcess")
                        .WithMany()
                        .HasForeignKey("BusinessProcessId");

                    b.Navigation("BusinessProcess");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcessStateTransition", b =>
                {
                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcess", "BusinessProcess")
                        .WithMany()
                        .HasForeignKey("BusinessProcessId");

                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcessState", "FromState")
                        .WithMany()
                        .HasForeignKey("FromStateId");

                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcessState", "ToState")
                        .WithMany()
                        .HasForeignKey("ToStateId");

                    b.Navigation("BusinessProcess");

                    b.Navigation("FromState");

                    b.Navigation("ToState");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.Endpoint", b =>
                {
                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.EndpointType", "EndpointType")
                        .WithMany()
                        .HasForeignKey("EndpointTypeId");

                    b.Navigation("EndpointType");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.EndpointCall", b =>
                {
                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcessState", "BusinessProcessState")
                        .WithMany()
                        .HasForeignKey("BusinessProcessStateId");

                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcessStateTransition", "BusinessProcessStateTransition")
                        .WithMany()
                        .HasForeignKey("BusinessProcessStateTransitionId");

                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.Endpoint", "EndpointFrom")
                        .WithMany()
                        .HasForeignKey("EndpointFromId");

                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.Endpoint", "EndpointTo")
                        .WithMany()
                        .HasForeignKey("EndpointToId");

                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.EndpointType", "EndpointTypeFrom")
                        .WithMany()
                        .HasForeignKey("EndpointTypeFromId");

                    b.HasOne("WorkflowLib.Examples.ServiceInteraction.Models.EndpointType", "EndpointTypeTo")
                        .WithMany()
                        .HasForeignKey("EndpointTypeToId");

                    b.Navigation("BusinessProcessState");

                    b.Navigation("BusinessProcessStateTransition");

                    b.Navigation("EndpointFrom");

                    b.Navigation("EndpointTo");

                    b.Navigation("EndpointTypeFrom");

                    b.Navigation("EndpointTypeTo");
                });

            modelBuilder.Entity("WorkflowLib.Examples.ServiceInteraction.Models.BusinessProcess", b =>
                {
                    b.Navigation("SubProcesses");
                });
#pragma warning restore 612, 618
        }
    }
}
