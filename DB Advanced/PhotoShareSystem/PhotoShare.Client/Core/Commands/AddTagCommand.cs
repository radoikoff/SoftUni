namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Services.Contracts;

    public class AddTagCommand : ICommand
    {
        private readonly ITagService tagService;

        public AddTagCommand(ITagService tagService)
        {
            this.tagService = tagService;
        }

        public string Execute(string[] args)
        {
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
