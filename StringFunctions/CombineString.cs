using System;

using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;

namespace SPandCRM
{
    public class CombineString : CodeActivity
    {
        [RequiredArgument]
        [Input("String")]
        public InArgument<String> FirstString { get; set; }

        [RequiredArgument]
        [Input("String to Add")]
        public InArgument<String> SecondString { get; set; }

        [Output("Combined String")]
        public OutArgument<String> CombinedString { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            // Combine the strings then set the output
            CombinedString.Set(context, FirstString.Get<String>(context) + SecondString.Get<String>(context));
        }
    }
}
