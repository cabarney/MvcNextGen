using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace UserGroup.TagHelpers
{
    [TargetElement(Attributes = "asp-visible")]
    public class VisibleTagHelper : TagHelper
    {
        public bool AspVisible { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!AspVisible)
            {
                output.SuppressOutput();
            }
        }
    }
}