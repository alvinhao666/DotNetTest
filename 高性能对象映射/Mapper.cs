using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace 高性能对象映射
{
    public class Mapper<TSource,TTarget> where TSource:class where TTarget:class
    {
        public readonly static Func<TSource, TTarget> Map;

        static Mapper()
        {
            if(Map==null)
            {
                Map = GetMap();
            }
        }

        private static Func<TSource,TTarget> GetMap()
        {
            var sourceType = typeof(TSource);
            var targeType = typeof(TTarget);

            var parameterExpression = Expression.Parameter(sourceType, "p");

            var memberInitExpression = GetExpression(parameterExpression, sourceType, targeType);

            var lambda = Expression.Lambda<Func<TSource, TTarget>>(memberInitExpression, parameterExpression);

            return lambda.Compile();

        }

        private static MemberInitExpression GetExpression(Expression parameterExpression, Type sourceType, Type targetType)
        {
            var memberBindings = new List<MemberBinding>();
            var properties = targetType.GetProperties().Where(x => x.PropertyType.IsPublic && x.CanWrite);
            foreach (var targetItem in properties)
            {
                var sourceItem = sourceType.GetProperty(targetItem.Name);

                //判断实体的读写权限
                if (sourceItem == null || !sourceItem.CanRead || sourceItem.PropertyType.IsNotPublic) continue;

                //标注NotMapped特性的属性忽略转换
                if (sourceItem.GetCustomAttribute<NotMappedAttribute>() != null) continue;

                var propertyExpression = Expression.Property(parameterExpression, sourceItem);

                // 判断都是class 且类型不相同时
                if (targetItem.PropertyType.IsClass && sourceItem.PropertyType.IsClass && targetItem.PropertyType != sourceItem.PropertyType)
                {
                    if (targetItem.PropertyType != targetType)//防止出现自己引用自己无限递归
                    {
                        var memberInit = GetExpression(propertyExpression, sourceItem.PropertyType, targetItem.PropertyType);
                        memberBindings.Add(Expression.Bind(targetItem, memberInit));
                        continue;
                    }
                }

                if (targetItem.PropertyType != sourceItem.PropertyType) continue;
                memberBindings.Add(Expression.Bind(targetItem, propertyExpression));
            }
            return Expression.MemberInit(Expression.New(targetType), memberBindings);
        }

    }
}
