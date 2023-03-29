using System;
using Core.Services.Updater;
using Player;
using UnityEngine;

namespace InputReader
{
    public class ExternalDevicesInputReader: IEntityInputSource, IDisposable
    {
        public float Direction => Input.GetAxisRaw("Horizontal");
        public bool Jump { get; private set; }
        public bool LongJump { get; private set; }

        public ExternalDevicesInputReader(IProjectUpdater projectUpdater)
        {
            ProjectUpdater.Instance.UpdateCalled += OnUpdate;
        }
        public void ResetOneTimeActions()
        {
            Jump = false;
            LongJump = false;
        }

        public void Dispose() => ProjectUpdater.Instance.UpdateCalled -= OnUpdate;
        private void OnUpdate()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump = true;
            }
            if (Input.GetButtonUp("Jump"))
            {
                LongJump = true;
            }
        }
    }
}
