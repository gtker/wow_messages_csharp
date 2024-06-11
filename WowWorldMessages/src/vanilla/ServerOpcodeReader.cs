using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

public interface VanillaServerMessage {}

public static class ServerOpcodeReader {
    public static async Task<VanillaServerMessage> ReadEncryptedAsync(Stream r, VanillaDecryption decrypter, CancellationToken cancellationToken = default) {
        var header = await decrypter.ReadServerHeaderAsync(r, cancellationToken).ConfigureAwait(false);

        unchecked {
            header.Size -= 2;
        }
        return await ReadBodyAsync(r, header, cancellationToken).ConfigureAwait(false);
    }
    public static async Task<VanillaServerMessage> ReadUnencryptedAsync(Stream r, CancellationToken cancellationToken = default) {
        var decrypter = new NullCrypter();
        var header = await decrypter.ReadServerHeaderAsync(r, cancellationToken).ConfigureAwait(false);

        unchecked {
            header.Size -= 2;
        }
        return await ReadBodyAsync(r, header, cancellationToken).ConfigureAwait(false);
    }
    private static async Task<VanillaServerMessage> ReadBodyAsync(Stream r, HeaderData header, CancellationToken cancellationToken = default) {
        return header.Opcode switch {
            58 => await SMSG_CHAR_CREATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            59 => await SMSG_CHAR_ENUM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            60 => await SMSG_CHAR_DELETE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            62 => await SMSG_NEW_WORLD.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            64 => await SMSG_TRANSFER_ABORTED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            65 => await SMSG_CHARACTER_LOGIN_FAILED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            66 => await SMSG_LOGIN_SETTIMESPEED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            76 => await SMSG_LOGOUT_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            77 => await SMSG_LOGOUT_COMPLETE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            79 => await SMSG_LOGOUT_CANCEL_ACK.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            81 => await SMSG_NAME_QUERY_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            83 => await SMSG_PET_NAME_QUERY_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            85 => await SMSG_GUILD_QUERY_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            91 => await SMSG_PAGE_TEXT_QUERY_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            93 => await SMSG_QUEST_QUERY_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            99 => await SMSG_WHO.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            101 => await SMSG_WHOIS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            103 => await SMSG_FRIEND_LIST.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            104 => await SMSG_FRIEND_STATUS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            107 => await SMSG_IGNORE_LIST.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            111 => await SMSG_GROUP_INVITE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            116 => await SMSG_GROUP_DECLINE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            119 => await SMSG_GROUP_UNINVITE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            121 => await SMSG_GROUP_SET_LEADER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            124 => await SMSG_GROUP_DESTROYED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            127 => await SMSG_PARTY_COMMAND_RESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            131 => await SMSG_GUILD_INVITE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            136 => await SMSG_GUILD_INFO.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            138 => await SMSG_GUILD_ROSTER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            146 => await SMSG_GUILD_EVENT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            147 => await SMSG_GUILD_COMMAND_RESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            153 => await SMSG_CHANNEL_NOTIFY.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            155 => await SMSG_CHANNEL_LIST.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            170 => await SMSG_DESTROY_OBJECT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            174 => await SMSG_READ_ITEM_OK.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            175 => await SMSG_READ_ITEM_FAILED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            176 => await SMSG_ITEM_COOLDOWN.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            179 => await SMSG_GAMEOBJECT_CUSTOM_ANIM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            181 => await MSG_MOVE_START_FORWARD_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            182 => await MSG_MOVE_START_BACKWARD_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            183 => await MSG_MOVE_STOP_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            184 => await MSG_MOVE_START_STRAFE_LEFT_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            185 => await MSG_MOVE_START_STRAFE_RIGHT_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            186 => await MSG_MOVE_STOP_STRAFE_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            187 => await MSG_MOVE_JUMP_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            188 => await MSG_MOVE_START_TURN_LEFT_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            189 => await MSG_MOVE_START_TURN_RIGHT_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            190 => await MSG_MOVE_STOP_TURN_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            191 => await MSG_MOVE_START_PITCH_UP_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            192 => await MSG_MOVE_START_PITCH_DOWN_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            193 => await MSG_MOVE_STOP_PITCH_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            194 => await MSG_MOVE_SET_RUN_MODE_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            195 => await MSG_MOVE_SET_WALK_MODE_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            199 => await MSG_MOVE_TELEPORT_ACK_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            201 => await MSG_MOVE_FALL_LAND_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            202 => await MSG_MOVE_START_SWIM_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            203 => await MSG_MOVE_STOP_SWIM_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            218 => await MSG_MOVE_SET_FACING_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            219 => await MSG_MOVE_SET_PITCH_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            222 => await SMSG_MOVE_WATER_WALK.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            223 => await SMSG_MOVE_LAND_WALK.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            226 => await SMSG_FORCE_RUN_SPEED_CHANGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            228 => await SMSG_FORCE_RUN_BACK_SPEED_CHANGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            230 => await SMSG_FORCE_SWIM_SPEED_CHANGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            232 => await SMSG_FORCE_MOVE_ROOT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            234 => await SMSG_FORCE_MOVE_UNROOT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            238 => await MSG_MOVE_HEARTBEAT_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            239 => await SMSG_MOVE_KNOCK_BACK.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            242 => await SMSG_MOVE_FEATHER_FALL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            243 => await SMSG_MOVE_NORMAL_FALL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            244 => await SMSG_MOVE_SET_HOVER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            245 => await SMSG_MOVE_UNSET_HOVER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            250 => await SMSG_TRIGGER_CINEMATIC.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            253 => await SMSG_TUTORIAL_FLAGS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            259 => await SMSG_EMOTE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            261 => await SMSG_TEXT_EMOTE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            275 => await SMSG_OPEN_CONTAINER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            277 => await SMSG_INSPECT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            288 => await SMSG_TRADE_STATUS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            289 => await SMSG_TRADE_STATUS_EXTENDED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            290 => await SMSG_INITIALIZE_FACTIONS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            291 => await SMSG_SET_FACTION_VISIBLE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            292 => await SMSG_SET_FACTION_STANDING.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            295 => await SMSG_SET_PROFICIENCY.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            297 => await SMSG_ACTION_BUTTONS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            298 => await SMSG_INITIAL_SPELLS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            299 => await SMSG_LEARNED_SPELL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            300 => await SMSG_SUPERCEDED_SPELL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            304 => await SMSG_CAST_RESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            307 => await SMSG_SPELL_FAILURE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            308 => await SMSG_SPELL_COOLDOWN.ReadBodyAsync(r, header.Size, cancellationToken).ConfigureAwait(false),
            309 => await SMSG_COOLDOWN_EVENT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            311 => await SMSG_UPDATE_AURA_DURATION.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            312 => await SMSG_PET_CAST_FAILED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            313 => await MSG_CHANNEL_START_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            314 => await MSG_CHANNEL_UPDATE_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            316 => await SMSG_AI_REACTION.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            323 => await SMSG_ATTACKSTART.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            324 => await SMSG_ATTACKSTOP.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            325 => await SMSG_ATTACKSWING_NOTINRANGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            326 => await SMSG_ATTACKSWING_BADFACING.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            327 => await SMSG_ATTACKSWING_NOTSTANDING.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            328 => await SMSG_ATTACKSWING_DEADTARGET.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            329 => await SMSG_ATTACKSWING_CANT_ATTACK.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            330 => await SMSG_ATTACKERSTATEUPDATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            334 => await SMSG_CANCEL_COMBAT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            336 => await SMSG_SPELLHEALLOG.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            337 => await SMSG_SPELLENERGIZELOG.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            341 => await SMSG_BINDPOINTUPDATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            344 => await SMSG_PLAYERBOUND.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            345 => await SMSG_CLIENT_CONTROL_UPDATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            347 => await SMSG_RESURRECT_REQUEST.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            353 => await SMSG_LOOT_RELEASE_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            354 => await SMSG_LOOT_REMOVED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            355 => await SMSG_LOOT_MONEY_NOTIFY.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            357 => await SMSG_LOOT_CLEAR_MONEY.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            358 => await SMSG_ITEM_PUSH_RESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            359 => await SMSG_DUEL_REQUESTED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            360 => await SMSG_DUEL_OUTOFBOUNDS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            361 => await SMSG_DUEL_INBOUNDS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            362 => await SMSG_DUEL_COMPLETE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            363 => await SMSG_DUEL_WINNER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            366 => await SMSG_MOUNTRESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            367 => await SMSG_DISMOUNTRESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            370 => await SMSG_MOUNTSPECIAL_ANIM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            371 => await SMSG_PET_TAME_FAILURE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            376 => await SMSG_PET_NAME_INVALID.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            378 => await SMSG_PET_MODE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            381 => await SMSG_GOSSIP_MESSAGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            382 => await SMSG_GOSSIP_COMPLETE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            384 => await SMSG_NPC_TEXT_UPDATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            387 => await SMSG_QUESTGIVER_STATUS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            389 => await SMSG_QUESTGIVER_QUEST_LIST.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            392 => await SMSG_QUESTGIVER_QUEST_DETAILS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            395 => await SMSG_QUESTGIVER_REQUEST_ITEMS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            397 => await SMSG_QUESTGIVER_OFFER_REWARD.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            399 => await SMSG_QUESTGIVER_QUEST_INVALID.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            401 => await SMSG_QUESTGIVER_QUEST_COMPLETE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            402 => await SMSG_QUESTGIVER_QUEST_FAILED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            405 => await SMSG_QUESTLOG_FULL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            406 => await SMSG_QUESTUPDATE_FAILED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            407 => await SMSG_QUESTUPDATE_FAILEDTIMER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            408 => await SMSG_QUESTUPDATE_COMPLETE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            409 => await SMSG_QUESTUPDATE_ADD_KILL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            410 => await SMSG_QUESTUPDATE_ADD_ITEM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            412 => await SMSG_QUEST_CONFIRM_ACCEPT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            415 => await SMSG_LIST_INVENTORY.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            417 => await SMSG_SELL_ITEM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            420 => await SMSG_BUY_ITEM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            421 => await SMSG_BUY_FAILED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            425 => await SMSG_SHOWTAXINODES.ReadBodyAsync(r, header.Size, cancellationToken).ConfigureAwait(false),
            427 => await SMSG_TAXINODE_STATUS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            430 => await SMSG_ACTIVATETAXIREPLY.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            431 => await SMSG_NEW_TAXI_PATH.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            433 => await SMSG_TRAINER_LIST.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            435 => await SMSG_TRAINER_BUY_SUCCEEDED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            436 => await SMSG_TRAINER_BUY_FAILED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            440 => await SMSG_SHOW_BANK.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            442 => await SMSG_BUY_BANK_SLOT_RESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            444 => await SMSG_PETITION_SHOWLIST.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            447 => await SMSG_PETITION_SHOW_SIGNATURES.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            449 => await SMSG_PETITION_SIGN_RESULTS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            453 => await SMSG_TURN_IN_PETITION_RESULTS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            455 => await SMSG_PETITION_QUERY_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            456 => await SMSG_FISH_NOT_HOOKED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            457 => await SMSG_FISH_ESCAPED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            459 => await SMSG_NOTIFICATION.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            461 => await SMSG_PLAYED_TIME.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            463 => await SMSG_QUERY_TIME_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            464 => await SMSG_LOG_XPGAIN.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            468 => await SMSG_LEVELUP_INFO.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            469 => await MSG_MINIMAP_PING_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            470 => await SMSG_RESISTLOG.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            471 => await SMSG_ENCHANTMENTLOG.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            473 => await SMSG_START_MIRROR_TIMER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            474 => await SMSG_PAUSE_MIRROR_TIMER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            475 => await SMSG_STOP_MIRROR_TIMER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            477 => await SMSG_PONG.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            478 => await SMSG_CLEAR_COOLDOWN.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            479 => await SMSG_GAMEOBJECT_PAGETEXT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            482 => await SMSG_SPELL_DELAYED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            490 => await SMSG_ITEM_TIME_UPDATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            491 => await SMSG_ITEM_ENCHANT_TIME_UPDATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            492 => await SMSG_AUTH_CHALLENGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            494 => await SMSG_AUTH_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            497 => await MSG_SAVE_GUILD_EMBLEM_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            499 => await SMSG_PLAY_SPELL_VISUAL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            501 => await SMSG_PARTYKILLLOG.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            503 => await SMSG_PLAY_SPELL_IMPACT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            504 => await SMSG_EXPLORATION_EXPERIENCE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            507 => await MSG_RANDOM_ROLL_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            508 => await SMSG_ENVIRONMENTAL_DAMAGE_LOG.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            511 => await MSG_LOOKING_FOR_GROUP_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            515 => await SMSG_REMOVED_SPELL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            518 => await SMSG_GMTICKET_CREATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            520 => await SMSG_GMTICKET_UPDATETEXT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            521 => await SMSG_ACCOUNT_DATA_TIMES.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            530 => await SMSG_GMTICKET_GETTICKET.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            532 => await SMSG_GAMEOBJECT_SPAWN_ANIM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            533 => await SMSG_GAMEOBJECT_DESPAWN_ANIM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            534 => await MSG_CORPSE_QUERY_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            536 => await SMSG_GMTICKET_DELETETICKET.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            537 => await SMSG_CHAT_WRONG_FACTION.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            539 => await SMSG_GMTICKET_SYSTEMSTATUS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            542 => await SMSG_SET_REST_START.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            546 => await SMSG_SPIRIT_HEALER_CONFIRM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            548 => await SMSG_GOSSIP_POI.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            566 => await SMSG_LOGIN_VERIFY_WORLD.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            571 => await SMSG_MAIL_LIST_RESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            573 => await SMSG_BATTLEFIELD_LIST.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            580 => await SMSG_ITEM_TEXT_QUERY_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            587 => await SMSG_SPELLLOGMISS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            590 => await SMSG_PERIODICAURALOG.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            591 => await SMSG_SPELLDAMAGESHIELD.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            592 => await SMSG_SPELLNONMELEEDAMAGELOG.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            596 => await SMSG_ZONE_UNDER_ATTACK.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            597 => await MSG_AUCTION_HELLO_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            604 => await SMSG_AUCTION_LIST_RESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            605 => await SMSG_AUCTION_OWNER_LIST_RESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            606 => await SMSG_AUCTION_BIDDER_NOTIFICATION.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            607 => await SMSG_AUCTION_OWNER_NOTIFICATION.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            608 => await SMSG_PROCRESIST.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            610 => await SMSG_DISPEL_FAILED.ReadBodyAsync(r, header.Size, cancellationToken).ConfigureAwait(false),
            611 => await SMSG_SPELLORDAMAGE_IMMUNE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            613 => await SMSG_AUCTION_BIDDER_LIST_RESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            614 => await SMSG_SET_FLAT_SPELL_MODIFIER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            615 => await SMSG_SET_PCT_SPELL_MODIFIER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            617 => await SMSG_CORPSE_RECLAIM_DELAY.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            623 => await MSG_LIST_STABLED_PETS_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            627 => await SMSG_STABLE_RESULT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            631 => await SMSG_PLAY_MUSIC.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            632 => await SMSG_PLAY_OBJECT_SOUND.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            635 => await SMSG_SPELLDISPELLOG.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            644 => await MSG_QUERY_NEXT_MAIL_TIME_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            645 => await SMSG_RECEIVED_MAIL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            646 => await SMSG_RAID_GROUP_ONLY.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            652 => await SMSG_PVP_CREDIT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            653 => await SMSG_AUCTION_REMOVED_NOTIFICATION.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            657 => await SMSG_SERVER_MESSAGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            661 => await SMSG_MEETINGSTONE_SETQUEUE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            663 => await SMSG_MEETINGSTONE_COMPLETE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            664 => await SMSG_MEETINGSTONE_IN_PROGRESS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            665 => await SMSG_MEETINGSTONE_MEMBER_ADDED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            668 => await SMSG_CANCEL_AUTO_REPEAT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            669 => await SMSG_STANDSTATE_UPDATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            670 => await SMSG_LOOT_ALL_PASSED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            671 => await SMSG_LOOT_ROLL_WON.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            673 => await SMSG_LOOT_START_ROLL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            674 => await SMSG_LOOT_ROLL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            676 => await SMSG_LOOT_MASTER_LIST.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            677 => await SMSG_SET_FORCED_REACTIONS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            678 => await SMSG_SPELL_FAILED_OTHER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            679 => await SMSG_GAMEOBJECT_RESET_STATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            681 => await SMSG_CHAT_PLAYER_NOT_FOUND.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            682 => await MSG_TALENT_WIPE_CONFIRM_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            683 => await SMSG_SUMMON_REQUEST.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            687 => await SMSG_PET_BROKEN.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            688 => await MSG_MOVE_FEATHER_FALL_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            692 => await SMSG_FEIGN_DEATH_RESISTED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            695 => await SMSG_DUEL_COUNTDOWN.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            696 => await SMSG_AREA_TRIGGER_MESSAGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            699 => await SMSG_MEETINGSTONE_JOINFAILED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            700 => await SMSG_PLAYER_SKINNED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            701 => await SMSG_DURABILITY_DAMAGE_DEATH.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            706 => await SMSG_INIT_WORLD_STATES.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            707 => await SMSG_UPDATE_WORLD_STATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            709 => await SMSG_ITEM_NAME_QUERY_RESPONSE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            710 => await SMSG_PET_ACTION_FEEDBACK.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            712 => await SMSG_CHAR_RENAME.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            715 => await SMSG_INSTANCE_SAVE_CREATED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            716 => await SMSG_RAID_INSTANCE_INFO.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            722 => await SMSG_PLAY_SOUND.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            726 => await MSG_INSPECT_HONOR_STATS_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            730 => await SMSG_FORCE_WALK_SPEED_CHANGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            732 => await SMSG_FORCE_SWIM_BACK_SPEED_CHANGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            734 => await SMSG_FORCE_TURN_RATE_CHANGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            736 => await MSG_PVP_LOG_DATA_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            740 => await SMSG_AREA_SPIRIT_HEALER_TIME.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            742 => await SMSG_WARDEN_DATA.ReadBodyAsync(r, header.Size, cancellationToken).ConfigureAwait(false),
            744 => await SMSG_GROUP_JOINED_BATTLEGROUND.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            745 => await MSG_BATTLEGROUND_PLAYER_POSITIONS_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            747 => await SMSG_BINDER_CONFIRM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            748 => await SMSG_BATTLEGROUND_PLAYER_JOINED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            749 => await SMSG_BATTLEGROUND_PLAYER_LEFT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            753 => await SMSG_PET_UNLEARN_CONFIRM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            756 => await SMSG_WEATHER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            762 => await SMSG_RAID_INSTANCE_MESSAGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            765 => await SMSG_CHAT_RESTRICTED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            766 => await SMSG_SPLINE_SET_RUN_SPEED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            767 => await SMSG_SPLINE_SET_RUN_BACK_SPEED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            768 => await SMSG_SPLINE_SET_SWIM_SPEED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            769 => await SMSG_SPLINE_SET_WALK_SPEED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            770 => await SMSG_SPLINE_SET_SWIM_BACK_SPEED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            771 => await SMSG_SPLINE_SET_TURN_RATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            772 => await SMSG_SPLINE_MOVE_UNROOT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            773 => await SMSG_SPLINE_MOVE_FEATHER_FALL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            774 => await SMSG_SPLINE_MOVE_NORMAL_FALL.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            775 => await SMSG_SPLINE_MOVE_SET_HOVER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            776 => await SMSG_SPLINE_MOVE_UNSET_HOVER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            777 => await SMSG_SPLINE_MOVE_WATER_WALK.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            778 => await SMSG_SPLINE_MOVE_LAND_WALK.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            779 => await SMSG_SPLINE_MOVE_START_SWIM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            780 => await SMSG_SPLINE_MOVE_STOP_SWIM.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            781 => await SMSG_SPLINE_MOVE_SET_RUN_MODE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            782 => await SMSG_SPLINE_MOVE_SET_WALK_MODE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            793 => await MSG_MOVE_TIME_SKIPPED_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            794 => await SMSG_SPLINE_MOVE_ROOT.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            796 => await SMSG_INVALIDATE_PLAYER.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            798 => await SMSG_INSTANCE_RESET.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            799 => await SMSG_INSTANCE_RESET_FAILED.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            800 => await SMSG_UPDATE_LAST_INSTANCE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            801 => await MSG_RAID_TARGET_UPDATE_Server.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            804 => await SMSG_PET_ACTION_SOUND.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            805 => await SMSG_PET_DISMISS_SOUND.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            808 => await SMSG_GM_TICKET_STATUS_UPDATE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            811 => await SMSG_UPDATE_INSTANCE_OWNERSHIP.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            815 => await SMSG_SPELLINSTAKILLLOG.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            816 => await SMSG_SPELL_UPDATE_CHAIN_TARGETS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            818 => await SMSG_EXPECTED_SPAM_RECORDS.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            827 => await SMSG_DEFENSE_MESSAGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            _ => throw new NotImplementedException()
        };
    }
    /// <summary>
    /// Expects an opcode to be the next sent. Returns null if type is not correct.
    /// </summary>
    public static async Task<T?> ExpectEncryptedOpcode<T>(Stream r, VanillaDecryption decrypter, CancellationToken cancellationToken = default) where T: class, VanillaServerMessage {
        if (await ReadEncryptedAsync(r, decrypter, cancellationToken).ConfigureAwait(false) is T c) {
            return c;
        }

        return null;
    }
    /// <summary>
    /// Expects an opcode to be the next sent. Returns null if type is not correct.
    /// </summary>
    public static async Task<T?> ExpectUnencryptedOpcode<T>(Stream r, CancellationToken cancellationToken = default) where T: class, VanillaServerMessage {
        if (await ReadUnencryptedAsync(r, cancellationToken).ConfigureAwait(false) is T c) {
            return c;
        }

        return null;
    }
}
