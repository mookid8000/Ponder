using System;
using NUnit.Framework;

namespace Ponder.Tests
{
    [TestFixture]
    public class TestPonder
    {
        [Test]
        public void CanReflectOnPropertyName_ReferenceType()
        {
            Assert.AreEqual("ReferenceTypeProperty", Reflect.PropertyName<SomeClass>(p => p.ReferenceTypeProperty));
        }

        [Test]
        public void CanReflectOnPropertyName_ValueTypes()
        {
            Assert.AreEqual("ValueTypeProperty", Reflect.PropertyName<SomeClass>(p => p.ValueTypeProperty));
            Assert.AreEqual("AnotherValueTypeProperty", Reflect.PropertyName<SomeClass>(p => p.AnotherValueTypeProperty));
        }

        [Test]
        public void CanReflectOnNestedPropertyNames_MixedTypes()
        {
            Assert.AreEqual("Embedded.Embedded.AnotherValueTypeProperty.Year",
                Reflect.PropertyName<SomeClass>(p => p.Embedded.Embedded.AnotherValueTypeProperty.Year));
        }

        class SomeClass
        {
            public string ReferenceTypeProperty { get; set; }
            public int ValueTypeProperty { get; set; }
            public DateTime AnotherValueTypeProperty { get; set; }
            public SomeClass Embedded { get; set; }
        }
    }
}