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
    public class ArtistControllerTest
    {
        [Fact]
        public async Task GetAllArtists_ShouldReturnListOfArtists()
        {
            // Arrange
            var mockService = new Mock<IArtistService>();
            mockService.Setup(s => s.GetAllArtistsAsync())
                       .ReturnsAsync(new List<Artist>
                       {
                           new Artist { ArtistId = 1, Name = "Andy C" },
                           new Artist { ArtistId = 2, Name = "High Contrast" }
                       });

            var controller = new ArtistController(mockService.Object);

            // Act
            var result = await controller.GetAllArtists();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var artists = Assert.IsAssignableFrom<IEnumerable<Artist>>(okResult.Value);
            Assert.Collection(artists,
                a => Assert.Equal("Andy C", a.Name),
                a => Assert.Equal("High Contrast", a.Name));
        }

        [Fact]
        public async Task GetArtistById_WhenNotFound_Returns404()
        {
            var mockService = new Mock<IArtistService>();
            mockService.Setup(s => s.GetArtistByIdAsync(99))
                       .ReturnsAsync((Artist)null);

            var controller = new ArtistController(mockService.Object);
            var result = await controller.GetArtistById(99);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task AddArtist_ShouldReturnCreatedAtAction()
        {
            var mockService = new Mock<IArtistService>();
            var newArtist = new Artist { ArtistId = 3, Name = "Logistics" };

            var controller = new ArtistController(mockService.Object);
            var result = await controller.AddArtist(newArtist);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedArtist = Assert.IsType<Artist>(createdResult.Value);
            Assert.Equal("Logistics", returnedArtist.Name);
        }

        [Fact]
        public async Task UpdateArtist_WithMismatchedId_ReturnsBadRequest()
        {
            var mockService = new Mock<IArtistService>();
            var artistToUpdate = new Artist { ArtistId = 5, Name = "Netsky" };

            var controller = new ArtistController(mockService.Object);
            var result = await controller.UpdateArtist(4, artistToUpdate);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Artist ID does not match.", badRequest.Value);
        }

        [Fact]
        public async Task DeleteArtist_ShouldReturnNoContent()
        {
            var mockService = new Mock<IArtistService>();
            mockService.Setup(s => s.DeleteAsync(1)).Returns(Task.CompletedTask);

            var controller = new ArtistController(mockService.Object);
            var result = await controller.DeleteArtist(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
