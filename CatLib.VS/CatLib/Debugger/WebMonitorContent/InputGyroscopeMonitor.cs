﻿/*
 * This file is part of the CatLib package.
 *
 * (c) Yu Bin <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: http://catlib.io/
 */

using CatLib.Debugger.WebMonitor.Handler;
using UnityEngine;

namespace CatLib.Debugger.WebMonitorContent
{
    /// <summary>
    /// 陀螺仪相关监控
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class InputGyroscopeMonitor
    {
        /// <summary>
        /// 陀螺仪相关监控
        /// </summary>
        /// <param name="monitor">监控</param>
        public InputGyroscopeMonitor([Inject(Required = true)]IMonitor monitor)
        {
            monitor.Monitor(new OnceRecordMonitorHandler("input.gyro.enabled.cmd", string.Empty, new[] { "tags.input.gyro" },
                () =>
                {
                    if (!Input.gyro.enabled)
                    {
                        return "[command.help.clickStart](debug://command/input-gyro-enable/true)";
                    }
                    return "[command.help.clickStop](debug://command/input-gyro-enable/false)";
                }));
            monitor.Monitor(new OnceRecordMonitorHandler("input.gyro.enabled", string.Empty, new[] { "tags.input.gyro" },
                () => Input.gyro.enabled));
            monitor.Monitor(new OnceRecordMonitorHandler("input.gyro.updateInterval", string.Empty, new[] { "tags.input.gyro" },
                () => Input.gyro.updateInterval));
            monitor.Monitor(new OnceRecordMonitorHandler("input.gyro.attitude.eulerAngles", string.Empty, new[] { "tags.input.gyro" },
                () => Input.gyro.attitude.eulerAngles));
            monitor.Monitor(new OnceRecordMonitorHandler("input.gyro.gravity", string.Empty, new[] { "tags.input.gyro" },
                () => Input.gyro.gravity));
            monitor.Monitor(new OnceRecordMonitorHandler("input.gyro.rotationRate", string.Empty, new[] { "tags.input.gyro" },
                () => Input.gyro.rotationRate));
            monitor.Monitor(new OnceRecordMonitorHandler("input.gyro.rotationRateUnbiased", string.Empty, new[] { "tags.input.gyro" },
                () => Input.gyro.rotationRateUnbiased));
            monitor.Monitor(new OnceRecordMonitorHandler("input.gyro.userAcceleration", string.Empty, new[] { "tags.input.gyro" },
                () => Input.gyro.userAcceleration));
        }
    }
}