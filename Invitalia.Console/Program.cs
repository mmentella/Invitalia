using FluentValidation;
using Newtonsoft.Json;
using System.Reflection;
using System.Reflection.Emit;

var settings = (dynamic)(new
{
    MyModel = new
    {
        MyIntProperty = new
        {
            Mandatory = true,
            MinValue = 1,
            MaxValue = 10,
        },
        MyStringProperty = new
        {
            Mandatory = false,
            MinLenght = 5,
            MaxLenght = 10,
        },
        MyBoolProperty = new
        {
            Mandatory = false,
            When = new
            {
                Property = "MyIntProperty",
                Values = new
                {
                    Type = "Interval",
                    InitialValue = 3,
                    FinalValue = 5
                },
                Rule = new
                {
                    Mandatory = true,
                    AllowedValues = new bool[] { true }
                }
            }
        }
    }
});

Type genericType = typeof(AbstractValidator<>);
Type modelType = typeof(MyModel);
Type baseType = genericType.MakeGenericType(modelType);

Type settingsType = settings.GetType();

AssemblyName assemblyName = new("DynamicValidators");
AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);

TypeBuilder typeBuilder = moduleBuilder.DefineType("ModelValidator", TypeAttributes.Public, baseType);
