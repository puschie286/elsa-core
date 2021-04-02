﻿using System;
using Elsa.Activities.Temporal;
using Quartz;

// ReSharper disable once CheckNamespace
namespace Elsa
{
    public static class ElsaOptionsExtensions
    {
        /// <summary>
        /// Adds temporal (time-based) activities to Elsa using the Quartz implementation. Also registers Quartz services itself.
        /// </summary>
        /// <param name="options">Elsa options</param>
        /// <param name="configureQuartzOptions"></param>
        /// <param name="configureQuartz">An optional service collection Quartz configuration callback</param>
        /// <param name="configureQuartzHostedService">Use this callback to further configure the Quartz hosted service</param>
        /// <returns>The Elsa options, enabling method chaining</returns>
        public static ElsaOptions AddQuartzTemporalActivities(
            this ElsaOptions options,
            Action<QuartzOptions>? configureQuartzOptions = default,
            Action<IServiceCollectionQuartzConfigurator>? configureQuartz = default,
            Action<QuartzHostedServiceOptions>? configureQuartzHostedService = default)
        {
            CommonTemporalActivityServices.AddCommonTemporalActivities(options, timer => timer.UseQuartzProvider(true, configureQuartzOptions, configureQuartz, configureQuartzHostedService));
            return options;
        }
    }
}