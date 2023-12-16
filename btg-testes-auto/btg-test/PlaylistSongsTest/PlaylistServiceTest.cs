using System.Collections.Generic;
using btg_testes_auto.PlaylistSongs;
using FluentAssertions;
using NSubstitute;

namespace btg_test.PlaylistSongsTest;

public class PlaylistServiceTest
{
    private readonly IPlaylistValidationService _mockPlaylistValidationService;
    private PlaylistService _sut;

    public PlaylistServiceTest()
    {
        _mockPlaylistValidationService = Substitute.For<IPlaylistValidationService>();
        _sut = new PlaylistService(_mockPlaylistValidationService);
    }

    [Fact]
    public void AddSongToPlaylist_ValidSong_ShouldReturnTrue()
    {
        // Arrange
        var playlist = new Playlist { Songs = new List<Song>(), MaxSongs = 10 };
        var validSong = new Song { Title = "Song Title", Artist = "Song Artist" };

        _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, validSong).Returns(true);

        // Act
        var result = _sut.AddSongToPlaylist(playlist, validSong);

        // Assert
        result.Should().BeTrue();
        playlist.Songs.Should().Contain(validSong);
        _mockPlaylistValidationService.Received(1).CanAddSongToPlaylist(playlist, validSong);
    }

    [Fact]
    public void AddSongToPlaylist_InvalidSong_ShouldReturnFalse()
    {
        // Arrange
        var playlist = new Playlist { Songs = new List<Song>(), MaxSongs = 10 };
        var invalidSong = new Song { Title = "Invalid Song", Artist = "Invalid Artist" };

        _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, invalidSong).Returns(false);

        // Act
        var result = _sut.AddSongToPlaylist(playlist, invalidSong);

        // Assert
        result.Should().BeFalse();
        playlist.Songs.Should().NotContain(invalidSong);
        _mockPlaylistValidationService.Received(1).CanAddSongToPlaylist(playlist, invalidSong);
    }

    [Fact]
    public void AddSongsToPlaylist_AddValidSongs_ShouldAddSongs()
    {
        // Arrange
        var playlist = new Playlist { Songs = new List<Song>(), MaxSongs = 10 };
        var validSongs = new List<Song>
        {
            new Song { Title = "Song 1", Artist = "Artist 1" },
            new Song { Title = "Song 2", Artist = "Artist 2" }
        };

        _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>()).Returns(true);

        // Act
        _sut.AddSongsToPlaylist(playlist, validSongs);

        // Assert
        playlist.Songs.Should().Contain(validSongs);
        _mockPlaylistValidationService.Received(2).CanAddSongToPlaylist(playlist, Arg.Any<Song>());
    }

    [Fact]
    public void AddSongsToPlaylist_AddInvalidSongs_ShouldNotAddSongs()
    {
        // Arrange
        var playlist = new Playlist { Songs = new List<Song>(), MaxSongs = 10 };
        var invalidSongs = new List<Song>
        {
            new Song { Title = "Invalid Song 1", Artist = "Invalid Artist 1" },
            new Song { Title = "Invalid Song 2", Artist = "Invalid Artist 2" }
        };

        _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>()).Returns(false);

        // Act
        _sut.AddSongsToPlaylist(playlist, invalidSongs);

        // Assert
        playlist.Songs.Should().BeEmpty();
        _mockPlaylistValidationService.Received(2).CanAddSongToPlaylist(playlist, Arg.Any<Song>());
    }
}
