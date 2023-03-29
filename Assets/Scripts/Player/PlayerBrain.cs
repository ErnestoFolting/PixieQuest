using System;
using System.Collections.Generic;
using System.Linq;
using Core.Services.Updater;
using Unity.VisualScripting;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerBrain: IDisposable
    {
        private readonly PlayerEntity _playerEntity;
        private readonly List<IEntityInputSource> _inputSources;
        public PlayerBrain(PlayerEntity playerEntity, List<IEntityInputSource> inputSources)
        {
            _playerEntity = playerEntity;
            _inputSources = inputSources;
            ProjectUpdater.Instance.FixedUpdateCalled += OnFixedUpdate;
        }

        public void Dispose()
        {
            ProjectUpdater.Instance.FixedUpdateCalled -= OnFixedUpdate;
        }
        
        private void OnFixedUpdate()
        {
            _playerEntity.MoveHorizontally(GetHorizontalDirection());
            if (IsJump)
            {
                _playerEntity.Jump();
            }

            if (IsLongJump)
            {
                _playerEntity.LongJump();
            }

            foreach (var source in _inputSources )
            {
                source.ResetOneTimeActions();
            }
        }

        private float GetHorizontalDirection()
        {
            foreach (var inputSource in _inputSources )
            {
                if (inputSource.Direction == 0) continue;
                return inputSource.Direction;
            }

            return 0;
        }

        private bool IsJump => _inputSources.Any(source => source.Jump);
        private bool IsLongJump => _inputSources.Any(source => source.LongJump);
    }
}