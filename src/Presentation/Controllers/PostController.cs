using Cyrus.Mongodb.Contracts;
using Domain;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
	private readonly IMongoRepository<Post> _repository;

	public PostController(IMongoRepository<Post> Repository)
	{
		_repository = Repository;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var res = await _repository.GetAllAsync();
		return Ok(res);
	}

	[HttpPost]
	public async Task<IActionResult> Post(PostViewModel model)
	{
		var mappedPost = model.Adapt<Post>();
		await _repository.AddAsync(mappedPost);
		return Ok();
	}

}
