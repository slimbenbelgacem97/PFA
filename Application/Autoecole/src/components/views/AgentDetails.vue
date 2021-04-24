<template>
  <div>
    <Nav />
    <div class="container">
      <div class="card">
        <img class="card-img-top" src="holder.js/100x180/" alt="" />
        <div class="card-body">
          <h4 class="card-title">{{ Agentname }} Nom Prenom</h4>
          <h6>{{ AgentFunction }}code/conduite</h6>
          Plain
          <hr />

          <kendo-scheduler
            :data-source="localDataSource"
            :date="date"
            :height="600"
            :timezone="'Etc/UTC'"
            :resources="resources"
          >
            <kendo-scheduler-view :type="'day'"></kendo-scheduler-view>
            <kendo-scheduler-view
              :type="'workWeek'"
              :selected="true"
            ></kendo-scheduler-view>
            <kendo-scheduler-view :type="'week'"></kendo-scheduler-view>
            <kendo-scheduler-view :type="'month'"></kendo-scheduler-view>
            <kendo-scheduler-view :type="'agenda'"></kendo-scheduler-view>
          </kendo-scheduler>
        </div>
      </div>
    </div>
  </div>
</template>
// docs : https://www.telerik.com/kendo-vue-ui/components/scheduler/
<script>
import Nav from "@/components/views/Nav.vue";

// import { SchedulerResource } from '@progress/kendo-scheduler-vue-wrapper'
import {
  Scheduler,
  SchedulerView
} from "@progress/kendo-scheduler-vue-wrapper";

export default {
  components: {
    "kendo-scheduler": Scheduler,
    "kendo-scheduler-view": SchedulerView,
    Nav
  },
  data() {
    return {
      date: new Date(),
      localDataSource: [
        {
          id: 1,
          start: new Date("2021/04/19 11:00 AM"),
          end: new Date("2021/04/19 1:00 PM"),
          title: "Meeting with investors",
          roomId: 1 // The unique identifier of the first room (Meeting Room 101)
        },
        {
          id: 2,
          start: new Date("2021/04/19 10:15 AM"),
          end: new Date("2021/04/19 12:30 PM"),
          title: "Job Interview",
          roomId: 2 // The unique identifier of the second room (Meeting Room 102)
        }
      ],
      resources: [
        {
          field: "roomId", // The field of the Scheduler event which contains the resource identifier.
          title: "Type de seance", // The label displayed in the Scheduler edit form for this resource.
          dataSource: [
            {
              text: "Code", // Text of the resource instance
              value: 1, // The identifier of the resource instance. Use that value to assign an event to this instance.
              color: "#1c9ec4" // Used as the background of events assigned to this resource.
            },
            { text: "Conduite", value: 2, color: "#ff7663" }
          ]
        }
      ]
    };
  }
};
</script>
<style lang=""></style>
