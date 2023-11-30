using System.Net.Http.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class CommentHttpClient : ICommentService
{
    private readonly HttpClient client;

    public CommentHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Comment> CreateCommentAsync(CommentCreationDto commentDto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/comments", commentDto);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Comment>();
    }

    public async Task<IEnumerable<Comment>> GetCommentsForPostAsync(int postId)
    {
        HttpResponseMessage response = await client.GetAsync($"/comments/{postId}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<Comment>>();
    }
}
