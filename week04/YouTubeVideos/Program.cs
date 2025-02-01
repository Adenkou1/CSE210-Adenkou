using System;
using System.Collections.Generic;


class Comment 
{
    public string CommenterName { get; set;}
    public string Text { get; set;}
    
    public Comment(string commenterName, string text)
{CommenterName = commenterName; 
Text = text;}
}

class Video
{
    public string Title { get; set;}
    public string Author {get; set;}
    public int Length { get; set;}
    private List<Comment> comments;
}
