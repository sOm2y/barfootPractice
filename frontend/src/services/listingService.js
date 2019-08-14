import axios from 'axios'

axios.defaults.baseURL = 'http://localhost:32522/api'

export const getListings = () => {
    return new Promise((resolve, reject) => {
        axios({
            method: 'get',
            url: '/listings',
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

export const createListing = (listingData) => {
    return new Promise((resolve, reject) => {
        axios({
            method: 'post',
            url: '/listings',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${JSON.parse(localStorage.getItem('token'))}`
            },
            data: listingData
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

export const updateListing = (listingId, listingData) => {
    return new Promise((resolve, reject) => {
        axios({
            method: 'put',
            url: `/listings/${listingId}`,
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${JSON.parse(localStorage.getItem('token'))}`
            },
            data: listingData
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
export const deleteListing = (listingId) => {
    return new Promise((resolve, reject) => {
        axios({
            method: 'delete',
            url: `/listings/${listingId}`,
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