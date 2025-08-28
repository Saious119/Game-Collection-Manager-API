﻿using GameCollectionManager.Shared.Models;
using GameCollectionManagerAPI.Services;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace GameCollectionManagerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IGDBController : ControllerBase
    {
        private ILog log = LogManager.GetLogger(typeof(Program));
        private readonly IIGDB_Service _iGDB_Service;

        public IGDBController(IIGDB_Service iGDB_Service)
        {
            _iGDB_Service = iGDB_Service;
        }

        [HttpGet("GetGameInfo/{game}")]
        public async Task<Game> GetGameInfoAsync(string game)
        {
            var result = await _iGDB_Service.GetIGDBInfo(game);
            result.multiplayer_mode_flags = await _iGDB_Service.GetMultiplayerModes(result.id);
            return result;
        }
        [HttpGet("GetGameCover/{coverID}")]
        public async Task<string> GetGameInfoAsync(int coverID)
        {
            var result = await _iGDB_Service.GetCoverArt(coverID);
            return result;
        }
    }
}
