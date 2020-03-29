﻿using System;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Tests.Common.Builders;
using Umbraco.Tests.Common.Builders.Extensions;

namespace Umbraco.Tests.UnitTests.Umbraco.Infrastructure.Models
{
    [TestFixture]
    public class MemberTests
    {
        private readonly MemberBuilder _builder = new MemberBuilder();

        [Test]
        public void Can_Deep_Clone()
        {
            // Arrange
            var member = BuildMember();

            // Act
            var clone = (Member)member.DeepClone();

            // Assert
            Assert.AreNotSame(clone, member);
            Assert.AreEqual(clone, member);
            Assert.AreEqual(clone.Id, member.Id);
            Assert.AreEqual(clone.VersionId, member.VersionId);
            Assert.AreEqual(clone.AdditionalData, member.AdditionalData);
            Assert.AreEqual(clone.ContentType, member.ContentType);
            Assert.AreEqual(clone.ContentTypeId, member.ContentTypeId);
            Assert.AreEqual(clone.CreateDate, member.CreateDate);
            Assert.AreEqual(clone.CreatorId, member.CreatorId);
            Assert.AreEqual(clone.Comments, member.Comments);
            Assert.AreEqual(clone.Key, member.Key);
            Assert.AreEqual(clone.FailedPasswordAttempts, member.FailedPasswordAttempts);
            Assert.AreEqual(clone.Level, member.Level);
            Assert.AreEqual(clone.Path, member.Path);
            Assert.AreEqual(clone.Groups, member.Groups);
            Assert.AreEqual(clone.Groups.Count(), member.Groups.Count());
            Assert.AreEqual(clone.IsApproved, member.IsApproved);
            Assert.AreEqual(clone.IsLockedOut, member.IsLockedOut);
            Assert.AreEqual(clone.SortOrder, member.SortOrder);
            Assert.AreEqual(clone.LastLockoutDate, member.LastLockoutDate);
            Assert.AreNotSame(clone.LastLoginDate, member.LastLoginDate);
            Assert.AreEqual(clone.LastPasswordChangeDate, member.LastPasswordChangeDate);
            Assert.AreEqual(clone.Trashed, member.Trashed);
            Assert.AreEqual(clone.UpdateDate, member.UpdateDate);
            Assert.AreEqual(clone.VersionId, member.VersionId);
            Assert.AreEqual(clone.RawPasswordValue, member.RawPasswordValue);
            Assert.AreNotSame(clone.Properties, member.Properties);
            Assert.AreEqual(clone.Properties.Count(), member.Properties.Count());
            for (var index = 0; index < member.Properties.Count; index++)
            {
                Assert.AreNotSame(clone.Properties[index], member.Properties[index]);
                Assert.AreEqual(clone.Properties[index], member.Properties[index]);
            }

            // this can be the same, it is immutable
            Assert.AreSame(clone.ContentType, member.ContentType);

            //This double verifies by reflection
            var allProps = clone.GetType().GetProperties();
            foreach (var propertyInfo in allProps)
                Assert.AreEqual(propertyInfo.GetValue(clone, null), propertyInfo.GetValue(member, null));
        }

        [Test]
        public void Can_Serialize_Without_Error()
        {
            var member = BuildMember();

            var json = JsonConvert.SerializeObject(member);
            Debug.Print(json);
        }

        private Member BuildMember()
        {
            return _builder
                .AddMemberType()
                    .WithId(99)
                    .WithAlias("memberType")
                    .WithName("Member Type")
                    .WithMembershipPropertyGroup()
                    .AddPropertyGroup()
                        .WithName("Content")
                        .WithSortOrder(1)
                        .AddPropertyType()
                            .WithPropertyEditorAlias(Constants.PropertyEditors.Aliases.TextBox)
                            .WithValueStorageType(ValueStorageType.Nvarchar)
                            .WithAlias("title")
                            .WithName("Title")
                            .WithSortOrder(1)
                            .WithDataTypeId(-88)
                            .Done()
                        .AddPropertyType()
                            .WithPropertyEditorAlias(Constants.PropertyEditors.Aliases.TextBox)
                            .WithValueStorageType(ValueStorageType.Ntext)
                            .WithAlias("bodyText")
                            .WithName("Body Text")
                            .WithSortOrder(2)
                            .WithDataTypeId(-87)
                            .Done()
                        .AddPropertyType()
                            .WithPropertyEditorAlias(Constants.PropertyEditors.Aliases.TextBox)
                            .WithValueStorageType(ValueStorageType.Nvarchar)
                            .WithAlias("author")
                            .WithName("Author")
                            .WithDescription("Name of the author")
                            .WithSortOrder(3)
                            .WithDataTypeId(-88)
                            .Done()
                        .Done()
                    .Done()
                .WithId(10)
                .WithKey(Guid.NewGuid())
                .WithName("Name")
                .WithUserName("user")
                .WithRawPasswordValue("raw pass")
                .WithEmail("email@email.com")
                .WithCreatorId(22)
                .WithCreateDate(DateTime.Now)
                .WithUpdateDate(DateTime.Now)
                .WithFailedPasswordAttempts(22)
                .WithLevel(3)
                .WithPath("-1, 4, 10")
                .WithIsApproved(true)
                .WithIsLockedOut(true)
                .WithLastLockoutDate(DateTime.Now)
                .WithLastLoginDate(DateTime.Now)
                .WithLastPasswordChangeDate(DateTime.Now)                
                .WithSortOrder(5)
                .WithTrashed(false)
                .AddMemberGroups()
                    .WithValue("group1")
                    .WithValue("group2")
                    .Done()
                .AddAdditionalData()
                    .WithKeyValue("test1", 123)
                    .WithKeyValue("test2", "hello")
                    .Done()
                .WithPropertyIdsIncrementingFrom(200)
                .AddPropertyData()
                    .WithKeyValue("title", "Name member")
                    .WithKeyValue("bodyText", "This is a subpage")
                    .WithKeyValue("author", "John Doe")
                    .Done()
                .Build();
        }
    }
}
