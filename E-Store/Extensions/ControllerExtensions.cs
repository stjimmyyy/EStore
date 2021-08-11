namespace E_Store.Extensions
{
    using System;
    using System.Collections.Generic;
    
    using Classes;
    
    using Microsoft.AspNetCore.Mvc;
    
    public static class ControllerExtensions
    {
        public static void AddFlashMessage(this Controller controller, FlashMessage message)
        {
            // this is the same thing as with the HtmlHelper extension; we can work with an empty list again
            var list = controller.TempData.DeserializeToObject<List<FlashMessage>>("Messages");
            
            list.Add(message);
            
            // we save the extended message list back to the JSON format and to the TempData collection
            controller.TempData.SerializeObject(list, "Messages");
        }

        public static void AddFlashMessage(this Controller controller, string message, FlashMessageType messageType)
        {
            controller.AddFlashMessage(new FlashMessage(message, messageType));
        }

        public static void AddDebugMessage(this Controller controller, Exception ex)
        {
            string message = ex.Message;

            if (ex.GetBaseException().Message != message)
            {
                message += Environment.NewLine + ex.GetBaseException().Message;
            }
            
            AddFlashMessage(controller, new FlashMessage(message, FlashMessageType.Danger));
        }
        
    }
}