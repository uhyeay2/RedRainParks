﻿using RedRainParks.Domain.Extensions;

namespace RedRainParks.Domain.Tests.Extensions
{
    [TestFixture]
    public class StringArrayExtensionTests
    {
        public static readonly object[] NullOrEmptyIEnumerables =
        {
            Array.Empty<string>(), Enumerable.Empty<string>(), new List<string>(), null!
        };

        public static readonly object[] AggregateWithCommasExpectedOutput =
        {
            new object[] { new string[] { "a", "b", "c" }, "a,\n b,\n c" },
            new object[] { new string[] { "1", "2", "3" }, "1,\n 2,\n 3" },
            new object[] { new string[] { "first", "second", "third" }, "first,\n second,\n third" },
            new object[] { new string[] { "Table_Column", "OtherTable_OtherColumn", "LastTable_LastColumn" }, "Table_Column,\n OtherTable_OtherColumn,\n LastTable_LastColumn" },
        };


        [Test, TestCaseSource(nameof(NullOrEmptyIEnumerables))]
        public void AggregateWithCommas_Given_EmptyArray_Should_ReturnEmptyString(IEnumerable<string> nullOrEmpty) =>
            Assert.That(nullOrEmpty.AggregateWithCommaNewLine(), Is.Empty);

        [Test, TestCaseSource(nameof(AggregateWithCommasExpectedOutput))]
        public void AggregateWithCommas_Given_ValidStrings_Should_ReturnStringsAggregated(IEnumerable<string> strings, string expected) =>
            Assert.That(strings.AggregateWithCommaNewLine(), Is.EqualTo(expected));

        [Test]
        public void AggregateWithCommas_Given_OnlyOneString_Should_NotAddComma() =>
            Assert.That(new string[] { "One String" }.AggregateWithCommaNewLine(), Is.EqualTo("One String"));
    }
}
