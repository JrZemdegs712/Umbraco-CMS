using System;
using Umbraco.Tests.Common.Builders.Interfaces;

namespace Umbraco.Tests.Common.Builders.Extensions
{
    public static class BuilderExtensions
    {
        public static T WithId<T>(this T builder, int id)
            where T : IWithIdBuilder
        {
            builder.Id = id;
            return builder;
        }

        public static T WithCreatorId<T>(this T builder, int creatorId)
            where T : IWithCreatorIdBuilder
        {
            builder.CreatorId = creatorId;
            return builder;
        }

        public static T WithCreateDate<T>(this T builder, DateTime createDate)
            where T : IWithCreateDateBuilder
        {
            builder.CreateDate = createDate;
            return builder;
        }

        public static T WithUpdateDate<T>(this T builder, DateTime updateDate)
            where T : IWithUpdateDateBuilder
        {
            builder.UpdateDate = updateDate;
            return builder;
        }

        public static T WithAlias<T>(this T builder, string alias)
            where T : IWithAliasBuilder
        {
            builder.Alias = alias;
            return builder;
        }

        public static T WithName<T>(this T builder, string name)
            where T : IWithNameBuilder
        {
            builder.Name = name;
            return builder;
        }

        public static T WithKey<T>(this T builder, Guid key)
            where T : IWithKeyBuilder
        {
            builder.Key = key;
            return builder;
        }

        public static T WithParentId<T>(this T builder, int parentId)
            where T : IWithParentIdBuilder
        {
            builder.ParentId = parentId;
            return builder;
        }

        public static T WithTrashed<T>(this T builder, bool trashed)
            where T : IWithTrashedBuilder
        {
            builder.Trashed = trashed;
            return builder;
        }

        public static T WithLevel<T>(this T builder, int level)
            where T : IWithLevelBuilder
        {
            builder.Level = level;
            return builder;
        }

        public static T WithPath<T>(this T builder, string path)
            where T : IWithPathBuilder
        {
            builder.Path = path;
            return builder;
        }

        public static T WithSortOrder<T>(this T builder, int sortOrder)
            where T : IWithSortOrderBuilder
        {
            builder.SortOrder = sortOrder;
            return builder;
        }

        public static T WithDescription<T>(this T builder, string description)
            where T : IWithDescriptionBuilder
        {
            builder.Description = description;
            return builder;
        }

        public static T WithIcon<T>(this T builder, string icon)
            where T : IWithIconBuilder
        {
            builder.Icon = icon;
            return builder;
        }

        public static T WithThumbnail<T>(this T builder, string thumbnail)
            where T : IWithThumbnailBuilder
        {
            builder.Thumbnail = thumbnail;
            return builder;
        }
    }
}
