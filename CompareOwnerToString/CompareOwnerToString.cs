using System;

using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;

namespace SPandCRM
{
    public class CompareOwnerToString : CodeActivity
    {
        [RequiredArgument]
        [Input("Owner")]
        public InArgument<String> Owner { get; set; }

        [RequiredArgument]
        [Input("String to Compare")]
        public InArgument<String> ComparisonString { get; set; }

        [Output("Is SYSTEM")]
        public OutArgument<Boolean> EqualsString { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            // Get the input paramaters
            String owner = Owner.Get<String>(executionContext);
            String comparitor = ComparisonString.Get<String>(executionContext);

            tracingService.Trace("Owner: " + owner);
            
            // Compare the inputted owner to comparison string then return true or false
            if(owner.Equals(comparitor))
            {
                EqualsString.Set(executionContext, true);
            } else
            {
                EqualsString.Set(executionContext, false);
            }
            
        }
    }
}
