using System;
using NUnit.Framework;

namespace Ponder.Tests
{
    [TestFixture]
    public class TestPonder
    {
        [Test]
        public void GetsNullIfDottingGoesThroughNullReferences()
        {
            Assert.IsNull(Reflect.Value(new SomeClass(), "Embedded.ReferenceTypeProperty"));
        }

        [Test]
        public void GetsNullIfDottingGoesThroughNonExistantProperty()
        {
            Assert.IsNull(Reflect.Value(new SomeClass(), "ThisPropertyDoesNotExist"));
            Assert.IsNull(Reflect.Value(new SomeClass(), "ThisPropertyDoesNotExist.TwoLevelsDeepNoErrors"));
        }

        [Test]
        public void CanGetValue()
        {
            Assert.AreEqual("someString", Reflect.Value(new SomeClass {ReferenceTypeProperty = "someString"},
                                                        "ReferenceTypeProperty"));
        }

        [Test]
        public void CanGetValuesThroughMultipleLevels()
        {
            const string somevalue = "someValue";
            Assert.AreEqual(somevalue.Length, Reflect.Value(new SomeClass {ReferenceTypeProperty = somevalue},
                                                            "ReferenceTypeProperty.Length"));
        }

        [Test]
        public void CanReflectOnPropertyName_ReferenceType()
        {
            Assert.AreEqual("ReferenceTypeProperty", Reflect.Path<SomeClass>(p => p.ReferenceTypeProperty));
        }

        [Test]
        public void CanReflectOnPropertyName_ValueTypes()
        {
            Assert.AreEqual("ValueTypeProperty", Reflect.Path<SomeClass>(p => p.ValueTypeProperty));
            Assert.AreEqual("AnotherValueTypeProperty", Reflect.Path<SomeClass>(p => p.AnotherValueTypeProperty));
        }

        [Test]
        public void CanReflectOnNestedPropertyNames_MixedTypes()
        {
            Assert.AreEqual("Embedded.Embedded.AnotherValueTypeProperty.Year",
                            Reflect.Path<SomeClass>(p => p.Embedded.Embedded.AnotherValueTypeProperty.Year));
        }

        [Test, Ignore("not implemented yet")]
        public void CanReflectOnNestedPropertyNamesAndMethods()
        {
            Assert.AreEqual("GetSomeClass().Embedded.ReferenceTypeProperty",
                            Reflect.Path<SomeClass>(p => p.GetSomeClass().Embedded.ReferenceTypeProperty));
        }

        [Test, Ignore("not implemented yet")]
        public void CanReflectOnNestedPropertyNamesAndMethodsIncludingArguments()
        {
            Assert.AreEqual("GetSomeClassAdvanced(\"hello world!\").Embedded.ReferenceTypeProperty",
                            Reflect.Path<SomeClass>(p => p.GetSomeClassAdvanced("hello world!").Embedded.ReferenceTypeProperty));
        }

        class SomeClass
        {
            public string ReferenceTypeProperty { get; set; }
            public int ValueTypeProperty { get; set; }
            public DateTime AnotherValueTypeProperty { get; set; }
            public SomeClass Embedded { get; set; }
            public SomeClass GetSomeClass()
            {
                return null; //<not important :)
            }
            public SomeClass GetSomeClassAdvanced(string someParameter)
            {
                return null;
            }
        }
    }
}