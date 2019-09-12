using System;

namespace SpringBoot注解式编程
{
    //属性注入式注解
    [AttributeUsage(AttributeTargets.Property)]
    public class AutowiredAttribute:Attribute
    {
        
    }
    
    //配置值注解
    [AttributeUsage(AttributeTargets.Property)]
    public class ValueAttribute : Attribute
    {
        public ValueAttribute(string value = "")
        {
            this.Value = value;
        }

        public string Value { get; }
    }

    //声明式事务注解
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionalAttribute : Attribute
    {
        
    }
}