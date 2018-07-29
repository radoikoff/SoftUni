namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Services.Contracts;

    public class AddTagCommand : ICommand
    {
        private readonly ITagService tagService;
        private readonly ISessionService sessionService;

        public AddTagCommand(ITagService tagService, ISessionService sessionService)
        {
            this.tagService = tagService;
            this.sessionService = sessionService;
        }

        public string Execute(string[] args)
        {
            if (!this.sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            string tagName = args[0];

            bool tagExists = this.tagService.Exists(tagName);

            if (tagExists)
            {
                throw new ArgumentException($"Tag {tagName} exists!");
            }

            var newTagName = tagName.ValidateOrTransform();

            var tag = this.tagService.AddTag(newTagName);

            return $"Tag {newTagName} was added successfully!";
        }
    }
}
