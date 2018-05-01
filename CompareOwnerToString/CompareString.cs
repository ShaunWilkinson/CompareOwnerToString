using System;

using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;

namespace SPandCRM
{
    public class CompareString : CodeActivity
    {
        [RequiredArgument]
        [Input("String")]
        public InArgument<String> OriginalString { get; set; }

        [RequiredArgument]
        [Input("String to Compare")]
        public InArgument<String> ComparisonString { get; set; }

        [Output("Is Equal")]
        public OutArgument<Boolean> EqualsString { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            // Get the input paramaters
            String originalString = OriginalString.Get<String>(executionContext);
            String comparitor = ComparisonString.Get<String>(executionContext);
            
            // Compare the inputted owner to comparison string then return true or false
            if(originalString.Equals(comparitor))
            {
                EqualsString.Set(executionContext, true);
            } else
            {
                EqualsString.Set(executionContext, false);
            }
            
        }
    }
}
