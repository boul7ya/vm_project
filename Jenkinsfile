pipeline {
    agent any

    stages {

        stage('MDB init') {
            steps {
                bat '''
                curl -X POST http://localhost:8080/mdb/data ^
                     -H "Content-Type: application/json" ^
                     --data @params.json
                '''
            }
        }

        stage('MDB open') {
            steps {
                bat 'curl -X POST http://localhost:8080/mdb/open/COM1'
            }
        }

        stage('MDB start') {
            steps {
                bat 'curl -X POST http://localhost:8080/mdb/start'
            }
        }

        stage('MDB vend') {
            steps {
                bat 'curl -X POST http://localhost:8080/mdb/vend/5'
            }
        }

        stage('MDB close') {
            steps {
                bat 'curl -X POST http://localhost:8080/mdb/close'
            }
        }

        stage('MDB state') {
            steps {
                bat 'curl http://localhost:8080/mdb/state'
            }
        }
    }

    post {
        always {
            bat 'docker rm -f mdb || exit 0'
        }
    }
}
