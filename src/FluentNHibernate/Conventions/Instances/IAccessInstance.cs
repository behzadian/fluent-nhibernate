using System;
using FluentNHibernate.Conventions.Inspections;
using NHibernate.Properties;

namespace FluentNHibernate.Conventions.Instances
{
    public interface IAccessInstance
    {
        void Property();
        void Field();
        void BackField();
        void CamelCaseField();
        void CamelCaseField(CamelCasePrefix prefix);
        void LowerCaseField();
        void LowerCaseField(LowerCasePrefix prefix);
        void PascalCaseField(PascalCasePrefix prefix);
        void ReadOnlyProperty();
        void NoSetterPropertyThroughCamelCaseField();
        void NoSetterPropertyThroughCamelCaseField(CamelCasePrefix prefix);
        void NoSetterPropertyThroughLowerCaseField();
        void NoSetterPropertyThroughLowerCaseField(LowerCasePrefix prefix);
        void NoSetterPropertyThroughPascalCaseField(PascalCasePrefix prefix);
        void Using(string propertyAccessorAssemblyQualifiedClassName);
        void Using(Type propertyAccessorClassType);
        void Using<TPropertyAccessorClass>() where TPropertyAccessorClass : IPropertyAccessor;
        void NoOp();
        void None();
    }
}