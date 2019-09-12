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
        
    }
}