import axios from 'axios'

axios.defaults.baseURL = 'http://localhost:32522/api'

export const getStaffs = (token) => {
    return new Promise((resolve, reject) => {
        axios({
            method: 'get',
            url: '/staffs',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${JSON.parse(localStorage.getItem('token'))}`
            }
        })
            .then(res => {
                if (res.status === 400 || res.status === 403) {
                    reject(res)
                }

                resolve(res.data)
            })
            .catch(err => {
                reject(err.response)
            })
    })
}

export const createStaff = (staffData) => {
    return new Promise((resolve, reject) => {
        axios({
            method: 'post',
            url: '/staffs',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${JSON.parse(localStorage.getItem('token'))}`
            },
            data: staffData
        })
            .then(res => {
                if (res.status === 400 || res.status === 403) {
                    reject(res)
                }

                resolve(res.data)
            })
            .catch(err => {
                reject(err.response)
            })
    })
}

export const updateStaff = (staffId, staffData) => {
    return new Promise((resolve, reject) => {
        axios({
            method: 'put',
            url: `/staffs/${staffId}`,
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${JSON.parse(localStorage.getItem('token'))}`
            },
            data: staffData
        })
            .then(res => {
                if (res.status === 400 || res.status === 403) {
                    reject(res)
                }

                resolve(res.data)
            })
            .catch(err => {
                reject(err.response)
            })
    })
}
export const deleteStaff = (staffId) => {
    return new Promise((resolve, reject) => {
        axios({
            method: 'delete',
            url: `/staffs/${staffId}`,
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${JSON.parse(localStorage.getItem('token'))}`
            }
        })
            .then(res => {
                if (res.status === 400 || res.status === 403) {
                    reject(res)
                }

                resolve(res.data)
            })
            .catch(err => {
                reject(err.response)
            })
    })
}