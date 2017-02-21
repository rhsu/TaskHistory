(function () {
    const app = angular.module('app');

    function TaskTableView(taskId, taskContent) {

        this.taskId = taskId,
        this.taskContent = taskContent,
        this.editorTaskContent = taskContent

        // valid editor states are:
        // 'initial' : indicates loaded from the database
        // 'confirmDelete' : indicates that user is about to delete it
        // 'deleted' : indicates passed the confirmDelete state
        // 'editing' : indicates that the task is in inline-editing mode

        this.editorState = 'initial',

        ///////////////////////////////
        //							//
        // state change functions	//
        //							//
        //////////////////////////////
        this.setInitialState = function () {
            this.editorTaskContent = taskContent;
            this.editorState = 'initial';
        },

        this.setConfirmDeleteState = function () {
            this.editorState = 'confirmDelete';
        },

        this.setDeletedState = function () {
            this.editorState = 'deleted';
        },

        this.setEditingState = function () {
            this.editorState = 'editing';
        }
    }

    app.factory('TaskTableViewFactory', function () {
        return {
            
            
            buildFromJson(jsonObj) {  
                const id = jsonObj.TaskId || -1;
                const content = jsonObj.TaskContent || '';

                return new TaskTableView(id, content);
            },
            
            buildFromJsonCollection(jsonObjCollection) {
                const retVal = []
                for (let i = 0; i < jsonObjCollection.length; i++) {
                    const task = this.buildFromJson(jsonObjCollection[i]);
                    retVal.push(task);
                }
                return retVal;
            },
            
            updateFromJson(jsonObj, task) {
                const id = jsonObj.TaskId || -1;
                const content = jsonObj.TaskContent || '';
                
                task.taskId = id;
                task.taskContent = content;
            }

        }
    });

}());
