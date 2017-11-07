﻿using Microsoft.VisualStudio.Shell;
using Spect.Net.VsPackage.Vsx;

namespace Spect.Net.VsPackage.Commands
{
    /// <summary>
    /// Export the default Z80 program command
    /// </summary>
    [CommandId(0x0808)]
    public class ExportDefaultZ80ProgramCommand : ExportZ80ProgramCommand
    {
        /// <summary>
        /// Allows the project node to run the default Z80 code file
        /// </summary>
        public override bool AllowProjectItem => true;

        /// <summary>
        /// The item is allowed only when there is a default code file selected
        /// </summary>
        protected override void OnQueryStatus(OleMenuCommand mc)
        {
            var project = Package.CodeDiscoverySolution.CurrentProject;
            var enabled = project.DefaultZ80CodeItem != null;
            if (enabled)
            {
                project.GetHierarchyByIdentity(project.DefaultZ80CodeItem.Identity, out var hierarchy, out _);
                enabled &= hierarchy != null;
            }
            mc.Enabled = enabled;
        }
    }
}