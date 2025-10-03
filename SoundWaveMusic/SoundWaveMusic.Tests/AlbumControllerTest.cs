using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoundWaveMusic.API.Controllers;
using SoundWaveMusic.BusinessLayer.Interfaces;
using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.Tests.Controllers
{
    public class AlbumControllerTest
    {
        private readonly Mock<IAlbumService> _mockAlbumService;
        private readonly AlbumController _controller;

        public AlbumControllerTest()
        {
            _mockAlbumService = new Mock<IAlbumService>();
            _controller = new AlbumController(_mockAlbumService.Object);
        }

        [Fact]
        public async Task GetAllAlbums_ReturnsOkResult_WithAlbumList()
        {
            // Arrange
            var albums = new List<Album>
            {
                new Album { AlbumId = 1, Title = "Journey", Label = "V Records" },
                new Album { AlbumId = 2, Title = "Echoes", Label = "Metalheadz" }
            };
            _mockAlbumService.Setup(s => s.GetAllAlbumsAsync()).ReturnsAsync(albums);

            // Act
            var result = await _controller.GetAllAlbums();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnAlbums = Assert.IsAssignableFrom<IEnumerable<Album>>(okResult.Value);
            Assert.Equal(2, ((List<Album>)returnAlbums).Count);
        }

        [Fact]
        public async Task GetAlbumById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var album = new Album { AlbumId = 1, Title = "Journey" };
            _mockAlbumService.Setup(s => s.GetAlbumByIdAsync(1)).ReturnsAsync(album);

            // Act
            var result = await _controller.GetAlbumById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnAlbum = Assert.IsType<Album>(okResult.Value);
            Assert.Equal("Journey", returnAlbum.Title);
        }

        [Fact]
        public async Task GetAlbumById_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            _mockAlbumService.Setup(s => s.GetAlbumByIdAsync(99)).ReturnsAsync((Album)null);

            // Act
            var result = await _controller.GetAlbumById(99);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task AddAlbum_ValidAlbum_ReturnsCreatedAtAction()
        {
            // Arrange
            var album = new Album { AlbumId = 3, Title = "New Release", Label = "Critical Music" };
            _mockAlbumService.Setup(s => s.AddAlbumAsync(album)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddAlbum(album);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result); // 👈 Fix here
            var createdAlbum = Assert.IsType<Album>(actionResult.Value);
            Assert.Equal("New Release", createdAlbum.Title);
        }

        [Fact]
        public async Task UpdateAlbum_MismatchedId_ReturnsBadRequest()
        {
            // Arrange
            var album = new Album { AlbumId = 1, Title = "Update Test" };

            // Act
            var result = await _controller.UpdateAlbum(2, album);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Album ID does not match.", badRequest.Value);
        }

        [Fact]
        public async Task DeleteAlbum_ValidId_ReturnsNoContent()
        {
            // Arrange
            _mockAlbumService.Setup(s => s.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteAlbum(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
