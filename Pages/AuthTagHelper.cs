using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CustomTagHelper.Pages
{
    [HtmlTargetElement("div", Attributes = "authcode")]
    [HtmlTargetElement("button", Attributes = "authcode")]
    public class AuthTagHelper : TagHelper
    {
        public string authcode { get; set; } = string.Empty;
        private IUser User { get; set; }

        public AuthTagHelper(IUser user)
        {
            User = user;
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // 条件に合致しない場合はタグを非表示
            if (!IsAuthorizedToShow(authcode))
            {
                output.SuppressOutput();
            }
            return Task.CompletedTask;
        }

        private bool IsAuthorizedToShow(string authCode)
        {
            // AuthCodeとユーザー名に基づいて表示可否を判定
            if (User.Name == "ALL") return true;

            return (authCode == User.Name);
        }
    }
}
