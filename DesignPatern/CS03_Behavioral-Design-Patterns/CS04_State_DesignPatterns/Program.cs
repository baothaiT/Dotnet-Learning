

using CS04_State_DesignPatterns.Services;

namespace CS04_State_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS04_State_DesignPatterns!");

        Document document = new Document();
        Console.WriteLine($"Current State: {document.GetCurrentState()}"); // DraftState

        // Trying to edit the document in Draft state
        document.Edit(); // Output: Document is in Draft state and can be edited.

        // Publishing the document, transitions to Moderation state
        document.Publish(); // Output: Document is sent for moderation.
        Console.WriteLine($"Current State: {document.GetCurrentState()}"); // ModerationState

        // Trying to edit in Moderation state
        document.Edit(); // Output: Document is under moderation and cannot be edited.

        // Publishing the document, transitions to Published state
        document.Publish(); // Output: Document is approved and published.
        Console.WriteLine($"Current State: {document.GetCurrentState()}"); // PublishedState

        // Trying to edit in Published state
        document.Edit(); // Output: Document is published and cannot be edited.

        // Trying to publish again in Published state
        document.Publish(); // Output: Document is already published.
    }
}