using CaseManagement.Models.CaseModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CaseManagement.Data.Extensions
{
    public static class CustomCasesOrderer
    {
        // Summary:
        //   Sorts a sequence of Cases.
        //
        // Parameters:
        //   source:
        //     A sequence of Cases to order.
        //   orderBy:
        //     String in the format: PropertyName-asc or PropertyName-desc.
        public static IOrderedQueryable<Case> CustomCasesOrder(this IQueryable<Case> source, string orderBy)
        {
            string orderByPropertyName = orderBy.Split('-').FirstOrDefault();

            string orderByDescOrAsc = orderBy.Split('-').LastOrDefault();
            bool ascending = orderByDescOrAsc == "asc" ? true : false;

            if (orderByPropertyName == "Status")
            {
                // Custom order by Status
                return ascending ? Queryable.OrderBy(source, orderByStatus)
                    : Queryable.OrderByDescending(source, orderByStatus);
            }
            else if (orderByPropertyName == "Priority")
            {
                // Custom order by Priority
                return ascending ? Queryable.OrderBy(source, orderByPriority)
                    : Queryable.OrderByDescending(source, orderByPriority);
            }
            else
            {
                // Default order for every other property dynamically at runtime
                ParameterExpression caseParam = Expression.Parameter(typeof(Case), "caseObj");
                MemberExpression prop = Expression.Property(caseParam, orderByPropertyName);

                UnaryExpression converted = Expression.Convert(prop, typeof(object));

                Expression<Func<Case, object>> lamba = Expression.Lambda<Func<Case, object>>(converted, caseParam);

                return ascending ? Queryable.OrderBy(source, lamba)
                    : Queryable.OrderByDescending(source, lamba);
            }
        }

        // The numbers returned correspond to the order/importance of the values
        private static readonly Expression<Func<Case, int>> orderByStatus = (caseObj) =>
            caseObj.Status.Status == "Other" ? 1 :
            caseObj.Status.Status == "Closed" ? 2 :
            caseObj.Status.Status == "On-hold" ? 3 :
            caseObj.Status.Status == "Resolved" ? 4 :
            caseObj.Status.Status == "In Process" ? 5 :
            caseObj.Status.Status == "Waiting" ? 6 :
            caseObj.Status.Status == "New" ? 7 :
            8;

        private static readonly Expression<Func<Case, int>> orderByPriority = (caseObj) =>
            caseObj.Priority.Priority == "Low" ? 1 :
            caseObj.Priority.Priority == "Normal" ? 2 :
            caseObj.Priority.Priority == "Urgent" ? 3 :
            caseObj.Priority.Priority == "Immediate" ? 4 :
            5;
    }
}
