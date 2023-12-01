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
        HttpResponseMessage response = await client.GetAsync($"/comments/posts/{postId}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<Comment>>();
    }

    public async Task<Comment> GetCommentByIdAsync(int commentId)
    {
        HttpResponseMessage response = await client.GetAsync($"/comments/{commentId}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Comment>();
    }

    public async Task<string> GetCommentOwnerUsernameAsync(int commentId)
    {
        HttpResponseMessage response = await client.GetAsync($"/comments/{commentId}/owner");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    public async Task UpdateCommentAsync(int commentId, UpdateCommentDto dto)
    {
        HttpResponseMessage response = await client.PutAsJsonAsync($"/Comments/comments/{commentId}", dto);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteCommentAsync(int commentId)
    {
        HttpResponseMessage response = await client.DeleteAsync($"/comments/comments/{commentId}");
        response.EnsureSuccessStatusCode();
    }
}

