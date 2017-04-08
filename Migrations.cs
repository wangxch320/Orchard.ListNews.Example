using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Data;
using Orchard.Indexing;
using ListNewsType.Models;

namespace ListNews.DataMigrations {
    public class Migrations : DataMigrationImpl {

        public int Create() {
            SchemaBuilder.CreateTable("ListNewsDetailRecord", table => table
				.ContentPartRecord()
                .Column("NewsTitle", DbType.String)
                .Column("NewsTypeof", DbType.String)
                .Column("NewsDate", DbType.String)
                .Column("NewsAuthor", DbType.String)
                .Column("NewsOrigin", DbType.String)
                .Column("Newsdetaltext", DbType.String, column => column.WithLength(3072))
                .Column("NewsImg", DbType.String)
			);

            SchemaBuilder.CreateTable("ListNewsTypeRecord", table => table
                .ContentPartRecord()
                .Column("ListNewsType", DbType.String)
                .Column("ListNewsTypeName", DbType.String)
            );

            SchemaBuilder.CreateTable("ListNewsRecord", table => table
                .ContentPartRecord()
                .Column("NewsTitle", DbType.String)
                .Column("NewsDate", DbType.String)
                .Column("NewsAuthor", DbType.String)
                .Column("NewsOrigin", DbType.String)
                .Column("Newsdetaltext", DbType.String)
                .Column("NewsImg", DbType.String)
            );
            return 1;
        }

		public int UpdateFrom1() {
		  ContentDefinitionManager.AlterPartDefinition("ListNewsPart",
			builder => builder.Attachable());
          ContentDefinitionManager.AlterPartDefinition("ListNewsTypePart",
            builder => builder.Attachable());
          ContentDefinitionManager.AlterPartDefinition("ListNewsDetailPart",
			builder => builder.Attachable());
		  return 2;
		}

        public int UpdateFrom2() {

            ContentDefinitionManager.AlterTypeDefinition("NewsDetailList", cfg => cfg
              .WithPart("CommonPart")
              .WithPart("TitlePart")
              .WithPart("RoutePart")
              .WithPart("ListNewsDetailPart")
              .WithPart("LocalizationPart")
              .Creatable()
              .Indexed());

            ContentDefinitionManager.AlterTypeDefinition("ListNewsTypeList", cfg => cfg
              .WithPart("CommonPart")
              .WithPart("TitlePart")
              .WithPart("RoutePart")
              .WithPart("ListNewsTypePart")
              .WithPart("LocalizationPart")
              .Creatable()
              .Indexed());
            return 3;
        }
    }
    /*
            private readonly IRepository<ListNewsTypeRecord> _ListNewsTypeRepository;

            public Migrations(IRepository<ListNewsTypeRecord> ListNewsTypeRepository)
            {
                _ListNewsTypeRepository = ListNewsTypeRepository;
            }

            private readonly IEnumerable<ListNewsTypeRecord> _ListNewsType =
                new List<ListNewsTypeRecord>
                {
                    new ListNewsTypeRecord {ListNewsType = "青海要闻"},
                    new ListNewsTypeRecord {ListNewsType = "本地动态"},
                    new ListNewsTypeRecord {ListNewsType = "党建动态"},
                    new ListNewsTypeRecord {ListNewsType = "政策信息"},
                    new ListNewsTypeRecord {ListNewsType = "特别关注"},
                    new ListNewsTypeRecord {ListNewsType = "通知公告"}
                };

            public int UpdateFrom3()
            {
                if (_ListNewsType == null)
                {
                    throw new InvalidOperationException("Couldn't find state repository.");
                }
                else
                {
                    foreach (var ListNewsType in _ListNewsType)
                    {
                        _ListNewsTypeRepository.Create(ListNewsType);
                    }
                }
                return 4;
            }*/
}