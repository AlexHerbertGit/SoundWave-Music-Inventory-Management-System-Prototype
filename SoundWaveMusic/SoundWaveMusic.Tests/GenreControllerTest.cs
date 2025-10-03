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
    public class GenreControllerTest
    {
        [Fact]
        public async Task GetAllGenres_ShouldReturnOkWithGenres()
        {
            // Arrange
            var mockService = new Mock<IGenreService>();
            mockService.Setup(s => s.GetAllGenresAsync()).ReturnsAsync(new List<Genre>
            {
                new Genre { GenreId = 1, Name = "Drum and Bass" },
                new Genre { GenreId = 2, Name = "Hip Hop" }
            });

            var controller = new GenreController(mockService.Object);

            // Act
            var result = await controller.GetAllGenres();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var genres = Assert.IsAssignableFrom<IEnumerable<Genre>>(okResult.Value);
            Assert.Collection(genres,
                g => Assert.Equal("Drum and Bass", g.Name),
                g => Assert.Equal("Hip Hop", g.Name));
        }

        [Fact]
        public async Task GetGenreById_NotFound_ShouldReturn404()
        {
            var mockService = new Mock<IGenreService>();
            mockService.Setup(s => s.GetGenreByIdAsync(99)).ReturnsAsync((Genre)null);

            var controller = new GenreController(mockService.Object);

            var result = await controller.GetGenreById(99);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task AddGenre_ShouldReturnCreatedAtAction()
        {
            var mockService = new Mock<IGenreService>();
            var genre = new Genre { GenreId = 1, Name = "Dubstep" };

            var controller = new GenreController(mockService.Object);

            var result = await controller.AddGenre(genre);

            var createdAtAction = Assert.IsType<CreatedAtActionResult>(result);
            var createdGenre = Assert.IsType<Genre>(createdAtAction.Value);
            Assert.Equal("Dubstep", createdGenre.Name);
        }
    }
}
