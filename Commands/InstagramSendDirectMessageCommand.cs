using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.Instagram.Commands
{
    [Command(Name = "instagram.senddm", Tooltip = "This command sends a message to the specified user.")]
    class InstagramSendDirectMessageCommand : G1ANT.Language.Command
    {
        public InstagramSendDirectMessageCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Message contents")]
            public TextStructure content { get; set; } = new TextStructure();
            [Argument(Required = true, Tooltip = "Recipient name here")]
            public TextStructure recipient { get; set; } = new TextStructure();
        }

        public void Execute(Arguments arguments)
        {
            AppiumWrapper.AppiumClick("action_bar_inbox_button", "id");
            AppiumWrapper.AppiumClick("New Message", "accessibilityid");
            AppiumWrapper.AppiumClick("recipients_container", "id");
            AppiumWrapper.AppiumTypeText("search_edit_text", arguments.recipient.Value, "id");
            AppiumWrapper.GetDriver().PressKeyCode(AndroidKeyCode.Enter);
            AppiumWrapper.AppiumClick("action_bar_button_text", "id");
            AppiumWrapper.AppiumTypeText("row_thread_composer_edittext", arguments.content.Value, "id");
            AppiumWrapper.AppiumClick("row_thread_composer_button_send", "id");
            AppiumWrapper.AppiumClick("action_bar_button_back", "id");
            AppiumWrapper.AppiumClick("action_bar_button_back", "id");
        }
    }
 }
